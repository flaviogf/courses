#!/bin/bash

status=$(curl -w %{http_code} --output /dev/null --silent localhost)

if [ $status -ne 200 ]
then
	mail -s "ERRO" flaviogf6@outlook.com<<d
Something is wrong with your server, we will try to restart it
d
	docker start httpd
fi

