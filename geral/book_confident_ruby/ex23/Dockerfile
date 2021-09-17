FROM ruby:2.7.4

WORKDIR /usr/local/app

COPY Gemfile* ./

RUN bundle

COPY . ./
