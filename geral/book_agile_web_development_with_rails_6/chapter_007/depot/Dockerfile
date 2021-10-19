FROM ruby:2.6.5

RUN apt-get install libsqlite3-dev \
    && curl -fsSL https://deb.nodesource.com/setup_12.x | bash - \
    && apt-get install -y nodejs \
    && curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add - \
    && echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list \
    && apt-get update && apt-get install -y yarn

WORKDIR /usr/local/app

COPY Gemfile* ./

RUN bundle

COPY package.json ./
COPY yarn.lock ./

RUN yarn

COPY . ./
