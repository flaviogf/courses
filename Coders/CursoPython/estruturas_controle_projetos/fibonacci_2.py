#!/usr/local/bin/python3


def fibonnaci(limite):
    inicio = 0
    fim = 1
    print(f'{inicio},{fim}', end=',')
    while fim <= limite:
        inicio, fim = fim, inicio + fim
        print(fim, end=',')


if __name__ == '__main__':
    fibonnaci(1000)
