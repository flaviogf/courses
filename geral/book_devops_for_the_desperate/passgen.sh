#!/bin/bash

pass=$(pwgen --secure --capitalize --numerals --symbols 12 1)

echo $pass | mkpasswd --stdin --method=sha-512

echo $pass
