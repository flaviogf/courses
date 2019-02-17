#!/usr/local/bin/python3

with open('pessoas.csv') as arquivo:
    for it in arquivo:
        print('Nome {}, Idade {}'.format(*it.strip().split(',')))
