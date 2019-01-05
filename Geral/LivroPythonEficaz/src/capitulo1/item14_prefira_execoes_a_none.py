def divisao(x: float, y: float):
    try:
        return True, x / y
    except ZeroDivisionError:
        return False, 0


def divisao2(x: float, y: float):
    try:
        return x / y
    except ZeroDivisionError as e:
        raise ValueError('entrada invalida') from e


if __name__ == '__main__':
    sucesso, resultado = divisao(10, 0)
    if sucesso:
        print(resultado)
    else:
        print('erro')

    sucesso, resultado = divisao(10, 10)
    if sucesso:
        print(resultado)
    else:
        print('erro')

    try:
        print(divisao2(10, 0))
    except ValueError as e:
        print(e)
