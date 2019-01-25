#!/usr/local/bin/python3
from math import pi


def circulo(raio):
    print(f'Area {pi * float(raio) ** 2}')


if __name__ == '__main__':
    raio = float(input('Informe o raio: '))
    circulo(raio)
