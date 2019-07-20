import json
from os import environ, path

import click
from flask import Flask
from flask_bcrypt import Bcrypt
from flask_login import LoginManager
from flask_mail import Mail
from flask_sqlalchemy import SQLAlchemy


app = Flask(__name__)

app.config['SECRET_KEY'] = '1722d954e7468232f0b08302b4449dda7f3621593658551768fd74dc9d8b4285'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///db.sqlite3'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
app.config['MAIL_SERVER'] = 'smtp.gmail.com'
app.config['MAIL_PORT'] = 587
app.config['MAIL_USE_TLS'] = True
app.config['MAIL_USERNAME'] = environ.get('MAIL_USERNAME')
app.config['MAIL_PASSWORD'] = environ.get('MAIL_PASSWORD')

db = SQLAlchemy(app)
bcrypt = Bcrypt(app)
login_manager = LoginManager(app)
login_manager.login_view = 'login'
mail = Mail(app)


@login_manager.user_loader
def load_user(user_id):
    return User.query.get(user_id)


@app.cli.command('seed', help='Add seed data to the database.')
def seed():
    def seed_user():
        User.query.delete()

        hashed_password = bcrypt.generate_password_hash('123')

        naruto = User(username='naruto',
                      email='naruto@uzumaki.com',
                      password=hashed_password)
        sasuke = User(username='sasuke',
                      email='sasuke@uzumaki.com',
                      password=hashed_password)

        db.session.add(naruto)
        db.session.add(sasuke)

    def seed_post():
        Post.query.delete()

        filename = path.join(path.dirname(__file__), 'posts.json')

        with open(filename) as file:
            posts = file.read()

            for post in json.loads(posts):
                db.session.add(Post(**post))

    seed_user()
    seed_post()

    db.session.commit()

    click.secho('Seed data added to the database', fg='green')


from flaskblog.models import Post, User
from flaskblog import db, views
