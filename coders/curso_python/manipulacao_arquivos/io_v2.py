#!/usr/local/bin/python3

arquivo = open('pessoas.csv')
for it in arquivo:
    print('Nome {}, Idade {}'.format(*it.strip().split(',')))
arquivo.close()
