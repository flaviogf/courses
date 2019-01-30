#!/usr/local/bin/python3


def fibonnaci(limite):
    proximo = -1
    inicio = 0
    fim = 1
    print(f'{inicio},{fim}', end=',')
    while proximo <= limite:
        proximo = inicio + fim
        print(proximo, end=',')
        inicio = fim
        fim = proximo


if __name__ == '__main__':
    fibonnaci(1000)
