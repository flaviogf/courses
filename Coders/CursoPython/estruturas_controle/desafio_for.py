#!/usr/local/bin/python3

from random import randint


def sortea_numero():
    return randint(1, 6)


def eh_impar(numero: float):
    return numero % 2 != 0


def acertou(numero_sorteado: float, numero: float):
    return numero_sorteado == numero


if __name__ == '__main__':
    numero_sorteado = sortea_numero()

    for it in range(1, 7):
        if eh_impar(it):
            continue

        if acertou(numero_sorteado, it):
            print('ACERTOU!', numero_sorteado)
            break
    else:
        print('NÃO ACERTOU O NUMERO!')
