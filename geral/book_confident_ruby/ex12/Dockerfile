FROM ruby:3.0.1

WORKDIR /usr/local/app

COPY Gemfile* ./Gemfile

RUN bundle

COPY . ./
