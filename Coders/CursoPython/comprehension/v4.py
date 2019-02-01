#!/usr/local/bin/python3

for numero, dobro in ({i: i * 2 for i in range(10) if i % 2 == 0}).items():
    print(f'{numero} x 2 = {dobro}')
