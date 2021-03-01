#!/usr/bin/bash

awk "/$1/ { print \$5, \$6, \$14 }" $2
