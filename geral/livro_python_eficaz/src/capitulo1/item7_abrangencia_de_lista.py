a = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

# quadrado de todos os numeros / map
print([x**2 for x in a])

# quadrado dos numeros pares / map filter
print([x**2 for x in a if x % 2 == 0])

b = {'ghost': 1, 'habanero': 2, 'cayenne': 3}

# troca chave por valor
print({numero: nome for nome, numero in b.items()})

# tamanho das chaves
print({len(nome) for nome in b.keys()})
