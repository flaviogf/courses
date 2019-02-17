#!/usr/local/bin/python3


def log(function):
    def decorator(*args, **kwargs):
        print(f'Inicio chamada funcao: {function.__name__}')
        resultado = function(*args, **kwargs)
        print(f'Resultado: {resultado}')
        print(f'Fim chamada funcao: {function.__name__}')
        return resultado

    return decorator


@log
def soma(x, y):
    return x + y


def sub(x, y):
    return x - y


if __name__ == '__main__':
    print(soma(10, 10))
    print(sub(10, y=5))
