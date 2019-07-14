from flask import redirect, render_template, url_for

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
        return redirect(url_for('home'))

    return render_template('login.html', title="Login", form=form)
