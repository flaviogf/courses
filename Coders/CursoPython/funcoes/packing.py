#!/usr/local/bin/python3


def soma_1(x, y):
    return x + y


def soma_2(x, y, z):
    return x + y + z


def soma(*numeros):
    return sum(numeros)


if __name__ == '__main__':
    print(soma_1(10, 10))
    print(soma_2(10, 10, 10))
    # packing
    print(soma(10, 10, 10, 10))
    # unpacking
    list_nums = [10, 20]
    print(soma_1(*list_nums))
    tuple_nums = (10, 20)
    print(soma_1(*tuple_nums))
