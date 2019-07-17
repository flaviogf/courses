from datetime import datetime

from flask_login import UserMixin
from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, Text
from sqlalchemy.orm import relationship

from flaskblog import db


class User(db.Model, UserMixin):
    id = Column(Integer,
                primary_key=True)
    username = Column(String(250),
                      nullable=False,
                      unique=True)
    email = Column(String(250),
                   nullable=False,
                   unique=True)
    image = Column(String(250),
                   nullable=False,
                   default='default.jpg')
    password = Column(String(250),
                      nullable=False)
    posts = relationship('Post', backref='author')

    def __repr__(self):
        return f"<User(id={self.id}), email='{self.email}')"


class Post(db.Model):
    id = Column(Integer,
                primary_key=True)
    title = Column(String(100),
                   nullable=False)
    date_posted = Column(DateTime,
                         nullable=False,
                         default=datetime.utcnow)
    content = Column(Text,
                     nullable=False)
    user_id = Column(Integer,
                     ForeignKey('user.id'),
                     nullable=False)

    def __repr__(self):
        return f"<Post(id='{self.id}', title='{self.title}')>"
