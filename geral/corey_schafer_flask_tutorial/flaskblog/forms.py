from flask_login import current_user
from flask_wtf import FlaskForm
from flask_wtf.file import FileAllowed, FileField
from wtforms import ValidationError
from wtforms.fields import (BooleanField, PasswordField, StringField,
                            SubmitField, TextAreaField)
from wtforms.validators import DataRequired, Email, EqualTo, Length

from flaskblog.models import User


class RegisterForm(FlaskForm):
    username = StringField('Username',
                           validators=[DataRequired(), Length(min=2, max=20)])
    email = StringField('E-mail',
                        validators=[DataRequired(), Email()])
    password = PasswordField('Password',
                             validators=[DataRequired()])
    confirm_password = PasswordField('Confirm Password',
                                     validators=[DataRequired(), EqualTo('password')])
    submit = SubmitField('Sign Up')

    def validate_username(self, field):
        user = User.query.filter_by(username=field.data).first()

        if user:
            raise ValidationError('That username is taken')

    def validate_email(self, field):
        user = User.query.filter_by(email=field.data).first()

        if user:
            raise ValidationError('That email is taken.')


class LoginForm(FlaskForm):
    email = StringField('E-mail',
                        validators=[DataRequired(), Email()])
    password = PasswordField('Password',
                             validators=[DataRequired()])
    remember = BooleanField('Remember')
    submit = SubmitField('Login')


class UpdateAccountForm(FlaskForm):
    username = StringField('Username',
                           validators=[DataRequired(), Length(min=2, max=20)])
    email = StringField('E-mail',
                        validators=[DataRequired(), Email()])
    image = FileField('Image', validators=[FileAllowed(('jpg', 'png'))])
    submit = SubmitField('Update')

    def validate_username(self, field):
        if field.data != current_user.username:
            user = User.query.filter_by(username=field.data).first()
            if user:
                raise ValidationError('That username is taken')

    def validate_email(self, field):
        if field.data != current_user.email:
            user = User.query.filter_by(email=field.data).first()
            if user:
                raise ValidationError('That email is taken.')


class PostForm(FlaskForm):
    title = StringField('Title',
                        validators=[DataRequired(), Length(min=2, max=100)])
    content = TextAreaField('Content',
                            validators=[DataRequired(), Length(min=5)])
    submit = SubmitField('Post')
