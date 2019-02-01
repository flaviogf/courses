#!/usr/local/bin/python3

with open('pessoas.csv') as arquivo:
    with open('pessoas.txt', 'w') as saida:
        for it in arquivo:
            pessoa = it.strip().split(',')
            print('Nome {}, Idade {}'.format(*pessoa), file=saida)
