FROM ruby:2.6.5

RUN curl -fsSL https://deb.nodesource.com/setup_12.x | bash - \
    && apt-get install nodejs -y \
    && curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add - \
    && echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list \
    && apt-get update && apt-get install --no-install-recommends yarn \
    && gem install rails -v 6.0.1 -N

WORKDIR /usr/local/app

COPY Gemfile* ./

RUN bundle

COPY package.json ./
COPY yarn.lock ./

RUN yarn

COPY . ./

EXPOSE 3000
