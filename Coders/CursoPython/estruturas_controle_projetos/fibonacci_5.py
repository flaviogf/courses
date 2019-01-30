#!/usr/local/bin/python3


def fibonnaci(quantidade):
    resultado = [0, 1]
    while True:
        resultado.append(sum(resultado[-2:]))
        if len(resultado) == quantidade:
            break
    return resultado


if __name__ == '__main__':
    for it in fibonnaci(20):
        print(it, end=',')
