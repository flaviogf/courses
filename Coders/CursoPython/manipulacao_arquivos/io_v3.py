#!/usr/local/bin/python3

try:
    arquivo = open('pessoas.csv')
    for it in arquivo:
        print('Nome {}, Idade {}'.format(*it.strip().split(',')))
finally:
    arquivo.close()
