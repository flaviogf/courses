#!/bin/env python

a = 0b11001001
mask = 0b11110000

x = (a & mask) >> 4

print(x)
