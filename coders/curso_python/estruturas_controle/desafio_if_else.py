#!/usr/local/bin/python3
from sys import argv, exit
from errno import EPERM, EINVAL


def calcula_conceito_nota(nota):
    if nota not in range(0, 11):
        return 'Nota invalida'

    if nota >= 9:
        return 'A'

    if nota >= 7:
        return 'B'

    if nota >= 5:
        return 'C'

    if nota >= 3:
        return 'D'

    if nota >= 1:
        return 'E'

    return 'F'


if __name__ == '__main__':
    if len(argv) < 2:
        print('Informe um nota')
        exit(EPERM)

    if not argv[1].isnumeric():
        print('Nota deve ser um numero')
        exit(EINVAL)

    nota = float(argv[1])
    conceito = calcula_conceito_nota(nota)

    print(conceito)
