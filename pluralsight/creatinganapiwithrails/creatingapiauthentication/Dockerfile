FROM ruby
WORKDIR /www
ARG USER_ID=1000
ARG GROUP_ID=1000
RUN addgroup --gid ${GROUP_ID} user
RUN adduser --uid ${USER_ID} --gid ${GROUP_ID} user
RUN apt-get update -y && apt-get install nodejs npm sqlite3 -y && npm install --global yarn && gem install rails
COPY . .
WORKDIR /www/project_tracker
RUN bundle install
EXPOSE 3000
ENTRYPOINT [ "rails", "server", "-b", "0.0.0.0" ]
