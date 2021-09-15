FROM jruby:9.2

WORKDIR /usr/local/app

COPY Gemfile* ./

RUN bundle

COPY . ./
