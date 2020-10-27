#!/bin/bash

total=$(free | grep -i mem | awk '{ print $2 }')

used=$(free | grep -i mem | awk '{ print $3 }')

relation=$(echo "scale=2;$used / $total * 100" | bc -l | awk -F. '{ print $1 }')

echo $relation

