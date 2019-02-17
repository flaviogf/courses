#!/usr/local/bin/python3


def imprime(maximo, atual):
    if atual >= maximo:
        return
    print(atual)
    imprime(maximo, atual + 1)


if __name__ == '__main__':
    imprime(100, 1)
