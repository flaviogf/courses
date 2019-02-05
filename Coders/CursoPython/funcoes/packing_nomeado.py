#!/usr/local/bin/python3


def resultado_f1(**kwargs):
    for posicao, piloto in kwargs.items():
        print(f'{posicao} -> {piloto}')


if __name__ == '__main__':
    resultado_f1(primeiro='Hamilton', segundo='Massa')
    podium = {'primeiro': 'Hamilton', 'segundo': 'Massa'}
    resultado_f1(**podium)
