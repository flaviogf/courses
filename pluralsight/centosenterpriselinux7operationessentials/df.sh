#!/usr/bin/bash

FILE=df.txt

df -h >> $FILE

mail -s "df $(date +%F)" root < $FILE && rm $FILE
