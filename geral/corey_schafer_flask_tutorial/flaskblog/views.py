from flask import redirect, render_template, request, url_for
from flask_login import login_required, login_user, logout_user

from flaskblog import app, bcrypt, db
from flaskblog.forms import LoginForm, RegisterForm
from flaskblog.models import User

posts = [
    {
        'author': 'Naruto',
        'title': 'Blog Post 1',
        'content': 'First content',
        'publication_date': 'April 20, 2019'
    }
]


@app.route('/')
@app.route('/home')
def home():
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

        return redirect(url_for('home'))

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

    return render_template('login.html', title="Login", form=form)


@app.route('/logout')
def logout():
    logout_user()
    return redirect(url_for('home'))


@app.route('/account')
@login_required
def account():
    return render_template('account.html', title='Acount')
