#!/bin/bash

status=$(curl -w %{http_code} --output /dev/null --silent localhost)

if [ $status -eq 200 ]
then
	echo "It's everything ok"
else
	echo "Something is wrong"
	docker start httpd
	echo "Apache was started"
fi

