FROM ruby
WORKDIR /www
ARG GROUP_ID=1000
ARG USER_ID=1000
RUN addgroup --gid ${GROUP_ID} user
RUN adduser --uid ${USER_ID} --gid ${GROUP_ID} user
RUN apt-get update -y && apt-get install sqlite3 nodejs npm -y && npm install --global yarn && gem install rails
COPY . .
RUN cd stocktracker && bundle install && rails webpacker:install
USER ${USER_ID}
EXPOSE 3000
