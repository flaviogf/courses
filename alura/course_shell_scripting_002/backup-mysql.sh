#!/bin/bash

cd $HOME

if [ ! -d backup ]
then
  mkdir backup
fi

docker exec -i mysql sh -c "exec mysqldump -uroot -proot $1" >> backup/$1.sql

if [ $? -eq 0 ]
then
  echo "Backup successfully"
else
  echo "Backup unsuccessfully"
fi

