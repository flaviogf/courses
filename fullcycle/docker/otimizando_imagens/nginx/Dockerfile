FROM nginx:1.15.0-alpine

RUN rm -rf /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

RUN mkdir -p /var/www/html && touch /var/www/html/index.php
