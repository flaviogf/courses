import secrets
from os import path

from flask import abort, flash, redirect, render_template, request, url_for
from flask_login import current_user, login_required, login_user, logout_user
from flask_mail import Message
from PIL import Image

from flaskblog import app, bcrypt, db, mail
from flaskblog.forms import (LoginForm, PostForm, RegisterForm,
                             RequestResetPassword, ResetPassword,
                             UpdateAccountForm)
from flaskblog.models import Post, User


@app.route('/')
@app.route('/home')
def home():
    page = request.args.get('page', 1, type=int)
    posts = Post.query.paginate(page=page, per_page=5)
    return render_template('home.html', posts=posts)


@app.route('/about')
def about():
    return render_template('about.html', title="About")


@app.route('/register', methods=['GET', 'POST'])
def register():
    form = RegisterForm()

    if form.validate_on_submit():
        hashed_password = bcrypt.generate_password_hash(form.password.data)

        user = User(username=form.username.data,
                    email=form.email.data,
                    password=hashed_password)

        db.session.add(user)
        db.session.commit()
        flash('Your account has been created')
        return redirect(url_for('login'))

    return render_template('register.html', title="Register", form=form)


@app.route('/login', methods=['GET', 'POST'])
def login():
    form = LoginForm()

    if form.validate_on_submit():
        user = User.query.filter_by(email=form.email.data).first()

        if user and bcrypt.check_password_hash(user.password, form.password.data):
            login_user(user, form.remember.data)
            next_url = request.args.get('next')
            return redirect(next_url) if next_url else redirect(url_for('home'))

        flash('Login Unsuccessful. Please check email and password')

    return render_template('login.html', title="Login", form=form)


@app.route('/logout')
def logout():
    logout_user()
    return redirect(url_for('home'))


@app.route('/account', methods=['GET', 'POST'])
@login_required
def account():
    form = UpdateAccountForm()

    if form.validate_on_submit():
        if form.image.data:
            current_user.image = save_image(form.image.data)
        current_user.username = form.username.data
        current_user.email = form.email.data
        db.session.commit()
        flash('Your account has been updated')
        return redirect(url_for('account'))
    elif request.method == 'GET':
        form.username.data = current_user.username
        form.email.data = current_user.email

    file_image = url_for('static', filename=f'pictures/{current_user.image}')

    return render_template('account.html', title='Acount', form=form, file_image=file_image)


@app.route('/post/new', methods=['GET', 'POST'])
@login_required
def new_post():
    form = PostForm()

    if form.validate_on_submit():
        post = Post(title=form.title.data,
                    content=form.content.data,
                    author=current_user)
        db.session.add(post)
        db.session.commit()
        return redirect(url_for('post', id=post.id))

    return render_template('create_post.html', title='New Post', form=form)


@app.route('/post/<int:id>')
def post(id):
    post = Post.query.get_or_404(id)
    return render_template('post.html', title=post.title, post=post)


@app.route('/post/<int:id>/update', methods=['GET', 'POST'])
@login_required
def update_post(id):
    post = Post.query.get_or_404(id)
    if post.author != current_user:
        abort(403)
    form = PostForm()
    if form.validate_on_submit():
        post.title = form.title.data
        post.content = form.content.data
        db.session.commit()
        return redirect(url_for('post', id=post.id))
    elif request.method == 'GET':
        form.title.data = post.title
        form.content.data = post.content
    return render_template('create_post.html', title='Update Post', form=form)


@app.route('/post/<int:id>/delete')
@login_required
def delete_post(id):
    post = Post.query.get_or_404(id)
    if post.author != current_user:
        abort(403)
    db.session.delete(post)
    db.session.commit()
    return redirect(url_for('home'))


@app.route('/request-reset-password', methods=['GET', 'POST'])
def request_reset_password():
    if current_user.is_authenticated:
        return redirect(url_for('home'))

    form = RequestResetPassword()

    if form.validate_on_submit():
        user = User.query.filter_by(email=form.email.data).first()

        if user:
            send_mail(user)
            flash('An email has been sent with instructions to reset your password.')
            return redirect(url_for('login'))

        flash('E-mail is not in use.')

    return render_template('request_reset_password.html',
                           title='Reset Password',
                           form=form)


@app.route('/reset-password/<string:token>', methods=['GET', 'POST'])
def reset_password(token):
    form = ResetPassword()

    if form.validate_on_submit():
        user = User.decode_token_reset(token)
        hashed_password = bcrypt.generate_password_hash(form.password.data)
        user.password = hashed_password
        db.session.commit()
        return redirect(url_for('login'))

    return render_template('reset_password.html', form=form)


def save_image(file):
    _, ext = path.splitext(file.filename)
    filename = secrets.token_hex(8) + ext
    filepath = path.join(app.root_path, 'static', 'pictures', filename)

    image = Image.open(file)
    image.resize((128, 128))
    image.save(filepath)

    return filename


def send_mail(user):
    message = Message(sender='noreply@flaskblog.com', recipients=[user.email])

    message.body = f'''To reset your password, visit the following link:
{url_for("reset_password", token=user.get_token_reset(), _external=True)}.
If you did not make this request then simply ignore this email and no changes will be made.'''

    mail.send(message)
