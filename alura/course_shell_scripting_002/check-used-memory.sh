#!/bin/bash

total=$(free | grep -i mem | awk '{ print $2 }')

used=$(free | grep -i mem | awk '{ print $3 }')

relation=$(echo "scale=2;$used / $total * 100" | bc -l | awk -F. '{ print $1 }')

if [ $relation -ge 5 ]
then
mail -s "Memory Oversize" flaviogf6@outlook.com<<d
  Currently, the used memory is $(free -h | grep -i mem | awk '{ print $3 }') because of this is recommended do something about it.
d
fi
