#!/bin/bash

processos=$(ps -e)

for processo in $processos
do
	echo $processo
done
