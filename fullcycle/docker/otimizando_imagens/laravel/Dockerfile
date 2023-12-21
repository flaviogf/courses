FROM php:7.4-cli AS build

WORKDIR /var/www

ENV COMPOSER_ALLOW_SUPERUSER=1

RUN apt-get update && \
    apt-get install unzip libmcrypt-dev -y && \
    pecl update-channels && \
    pecl install mcrypt-1.0.4 && \
    docker-php-ext-enable mcrypt

RUN php -r "copy('https://getcomposer.org/installer', 'composer-setup.php');" && \
    php composer-setup.php && \
    php -r "unlink('composer-setup.php');"

RUN php composer.phar create-project --prefer-dist laravel/laravel laravel

FROM php:7.4-fpm-alpine
WORKDIR /var/www
RUN rm -rf /var/www/html
COPY --from=build /var/www/laravel .
RUN chown -R www-data:www-data /var/www
RUN ln -sf /var/www/public /var/www/html
EXPOSE 9000
CMD [ "php-fpm" ]
