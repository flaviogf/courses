#!/bin/bash

if [ -z $1 ]
then
	while [ -z $method ]; do
		read -p "Enter a method (GET, POST, DELETE, PUT): " method
	done
else
	method=$1
fi

option=`echo $method | awk '{ print toupper($1) }'`

case $option in
	GET)
		cat apache.log | grep GET
	;;
	POST)
		cat apache.log | grep POST
	;;
	DELETE)
		cat apache.log | grep DELETE
	;;
	PUT)
		cat apache.log | grep PUT
	;;
	*)
		echo "Invalid method"
	;;
esac
