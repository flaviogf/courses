# array com tamanho de cada linha do arquivo
value = [len(linha) for linha in open('arquivo.txt')]
print(value)
print(type(value))

# expressao geradora
value = (len(linha) for linha in open('arquivo.txt'))
print(value)
print(next(value))
print(type(value))

# iteração em generators
value = (len(linha) for linha in open('arquivo.txt'))
for item in value:
    print(item)
