FROM ruby:2.6.5

WORKDIR /www

RUN apt-get install libsqlite3-dev \
    && curl -fsSL https://deb.nodesource.com/setup_12.x | bash - \
    && apt-get install -y nodejs
