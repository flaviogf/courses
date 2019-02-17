#!/usr/local/bin/python3
from math import pi
from sys import argv


def circulo(raio):
    return pi * float(raio)**2


if __name__ == '__main__':
    if len(argv) < 2:
        print('É necessario informar a area do circulo')
        print(f'Sintaxe: {argv[0][2:]} <raio>')
    else:
        raio = argv[1]
        area = circulo(raio)
        print(f'Area {area}')
