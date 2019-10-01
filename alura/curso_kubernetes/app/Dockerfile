FROM python:3.7
WORKDIR /app
COPY requirements.txt requirements.txt
RUN pip install -r requirements.txt
COPY . .
EXPOSE 80
ENTRYPOINT ["gunicorn", "-b", "0.0.0.0:80", "manage:app"]
