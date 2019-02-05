#!/usr/local/bin/python3


def todos_parametros(*args, **kwargs):
    print(f'args {args}')
    print(f'kwargs {kwargs}')


if __name__ == '__main__':
    todos_parametros(1, 2, [1, 2], fragil=True, valor=1500.0)
