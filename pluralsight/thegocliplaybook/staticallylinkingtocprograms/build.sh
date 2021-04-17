#!/usr/bin/bash

go build -buildmode=c-archive hello.go

gcc -o hello hello.c ./hello.a -lpthread
