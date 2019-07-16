from flask_login import UserMixin
from sqlalchemy import Column, Integer, String

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

    def __repr__(self):
        return f"<User(id={self.id}), email='{self.email}')"
