#!/bin/bash

today=$(date +"%F")

mkdir -p $HOME/backup/$today

tables=$(docker exec -i mysql sh -c "mysql -uroot -p$PASSWORD multillidea -e 'show tables;'" 2>/dev/null | grep -v "Tables")

for table in $tables
do
  docker exec -i mysql sh -c "mysqldump -uroot -p$PASSWORD multillidea $table" > $HOME/backup/$today/$table.sql 2>/dev/null
done
