#!/usr/local/bin/python3

import pdb
from urllib import request
from csv import reader


def baixa(arquivo):
    with request.urlopen(arquivo) as ibge:
        dados = ibge.read().decode('latin1')
        for it in reader(dados.splitlines()):
            print(f'{it[8]} - {it[3]}')


if __name__ == '__main__':
    arquivo = r'https://raw.githubusercontent.com/cod3rcursos/curso-python/master/manipulacao_arquivos/desafio-ibge.csv'
    baixa(arquivo)
