from flask_wtf import FlaskForm
from wtforms.fields import StringField, SubmitField, PasswordField
from wtforms.validators import DataRequired, Email, EqualTo, Length


class RegisterForm(FlaskForm):
    username = StringField('Username', validators=[
                           DataRequired(),
                           Length(min=2, max=20)])
    email = StringField('E-mail', validators=[
                        DataRequired(),
                        Email()])
    password = PasswordField('Password', validators=[
                           DataRequired()])
    confirm_password = PasswordField('Confirm Password', validators=[
                                   DataRequired(),
                                   EqualTo('password')])
    sign_up = SubmitField('Sign Up')
