#!/usr/local/bin/python3


def calcula_imposto(preco_bruco, imposto, **args):
    return preco_bruco + preco_bruco * imposto(**args)


def imposto_x(importado):
    return 0.5 if importado else 0


def imposto_y(explosivo, fator_mult=1):
    return 0.5 * fator_mult if explosivo else 0


if __name__ == '__main__':
    print(calcula_imposto(100, imposto_x, importado=True))
    print(calcula_imposto(100, imposto_x, importado=False))
    print(calcula_imposto(100, imposto_y, explosivo=True, fator_mult=10))
    print(calcula_imposto(100, imposto_y, explosivo=False, fator_mult=10))
