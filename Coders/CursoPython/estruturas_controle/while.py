#!/usr/local/bin/python3

from random import randint

numero_secreto = randint(1, 6)
numero_informado = -1

while numero_secreto != numero_informado:
    numero_informado = int(input('NUMERO: '))

print(f'ACERTOU! NUMERO SECRETO = {numero_secreto}')
