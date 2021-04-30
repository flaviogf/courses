FROM ruby
WORKDIR /www
RUN apt-get update -y && apt-get install sqlite3 nodejs npm -y && npm install --global yarn && gem install rails
COPY . .
RUN cd stocktracker && bundle install
EXPOSE 3000
