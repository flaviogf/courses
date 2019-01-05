nomes = ['flavio', 'fernando', 'luis', 'fatima']
tamanho_nomes = [len(nome) for nome in nomes]

maior_nome = None
tamanho_maximo = 0

for i, nome in enumerate(nomes):
    contador = tamanho_nomes[i]
    if contador > tamanho_maximo:
        tamanho_maximo = contador
        maior_nome = nomes[i]

print("SEM ZIP")
print(tamanho_maximo)
print(maior_nome)


for nome, tamanho_nome in zip(nomes, tamanho_nomes):
    if tamanho_maximo > tamanho_maximo:
        tamanho_maximo = tamanho_nome
        maior_nome = nome

print("COM ZIP")
print(tamanho_maximo)
print(maior_nome)

print(tamanho_nomes)
print(nomes)
