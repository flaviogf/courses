FROM python:3.6
WORKDIR /usr/app
RUN pip install pipenv
COPY ./Pipfile ./Pipfile
RUN pipenv install
COPY ./app.py ./app.py
EXPOSE 5000
ENV FLASK_APP=app.py
ENTRYPOINT pipenv run flask run
