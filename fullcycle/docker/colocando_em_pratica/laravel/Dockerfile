FROM php:7.4-cli

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

ENTRYPOINT [ "php", "laravel/artisan", "serve" ]

CMD [ "--host", "0.0.0.0" ]
