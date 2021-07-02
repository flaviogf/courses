FROM ruby:2.6

RUN apt-get update -yqq
RUN apt-get install nodejs -yqq --no-install-recommends

WORKDIR /usr/local/app

COPY . .

RUN bundle install
