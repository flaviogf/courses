#!/usr/local/bin/python3

generator = (i * 2 for i in range(10) if i % 2 == 0)

print(next(generator))  # Saida 0
print(next(generator))  # Saida 4
print(next(generator))  # Saida 8
print(next(generator))  # Saida 12
print(next(generator))  # Saida 16
# print(next(generator))  # Erro
