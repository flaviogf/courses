matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]

# permitido / reduce
print([item for row in matrix for item in row])

# permitido / quadrado do itens dos arrays iternos
print([[item**2 for item in row] for row in matrix])
