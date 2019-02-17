#!/usr/local/bin/python3
def executa(funcao):
    print('execuntando ...')
    funcao()
    print('fim da execucao ...')


def bom_dia():
    print('bom dia')


def boa_tarde():
    print('boa tarde')


if __name__ == '__main__':
    executa(bom_dia)
    executa(boa_tarde)
