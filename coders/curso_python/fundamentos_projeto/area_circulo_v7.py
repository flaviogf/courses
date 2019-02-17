#!/usr/local/bin/python3
from math import pi
from sys import argv


def circulo(raio):
    return pi * float(raio)**2


if __name__ == '__main__':
    raio = argv[1]
    area = circulo(raio)
    print(f'Area {area}')
