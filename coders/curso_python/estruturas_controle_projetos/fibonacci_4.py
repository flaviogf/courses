#!/usr/local/bin/python3


def fibonnaci(limite):
    resultado = [0, 1]
    while resultado[-1] <= limite:
        resultado.append(sum(resultado[-2:]))
    return resultado


if __name__ == '__main__':
    for it in fibonnaci(1000):
        print(it, end=',')
