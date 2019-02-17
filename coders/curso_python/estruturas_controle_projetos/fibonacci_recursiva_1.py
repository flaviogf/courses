#!/usr/local/bin/python3


def fibonacci(quantidade, resultado=[0, 1]):
    if len(resultado) > quantidade:
        return resultado

    resultado.append(sum(resultado[-2:]))
    return fibonacci(quantidade, resultado)


if __name__ == '__main__':
    for it in fibonacci(5):
        print(it)
