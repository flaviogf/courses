#!/usr/local/bin/python3
from math import pi
from sys import argv, exit
from errno import EPERM, EINVAL


def help():
    print('É necessario informar a area do circulo')
    print(f'Sintaxe: {argv[0][2:]} <raio>')


def circulo(raio):
    return pi * float(raio)**2


if __name__ == '__main__':
    if len(argv) < 2:
        help()
        exit(EPERM)

    if not argv[1].isnumeric():
        help()
        print('O <raio> deve ser um número')
        exit(EINVAL)

    raio = argv[1]
    area = circulo(raio)
    print(f'Area {area}')
