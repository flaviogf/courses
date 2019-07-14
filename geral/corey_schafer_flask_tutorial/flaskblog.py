from flask import Flask, redirect, render_template, url_for
from flask_sqlalchemy import SQLAlchemy

from forms import RegisterForm, LoginForm

app = Flask(__name__)

app.config['SECRET_KEY'] = '1722d954e7468232f0b08302b4449dda7f3621593658551768fd74dc9d8b4285'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///db.sqlite3'

db = SQLAlchemy(app)


class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(250), nullable=False)
    email = db.Column(db.String(250), nullable=False)
    password = db.Column(db.String(250), nullable=False)

    def __repr__(self):
        return f"<User(id={self.id}), email='{self.email}')"


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
        return redirect(url_for('home'))

    return render_template('register.html', title="Register", form=form)


@app.route('/login', methods=['GET', 'POST'])
def login():
    form = LoginForm()

    if form.validate_on_submit():
        return redirect(url_for('home'))

    return render_template('login.html', title="Login", form=form)
