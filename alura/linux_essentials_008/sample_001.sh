#!/bin/bash

echo "compacting files in $(pwd)"

tar -czvf files.tar.gz *.$1
