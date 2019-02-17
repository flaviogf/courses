var sala001 = [
    "Flavio": 10,
    "Fernando": 8,
    "Fatima": 5,
    "Luis Fernando": 7
]

var sala002 = [
    "Flavio": 9,
    "Teste1": 10,
    "Fernando": 10
]

sala001.merge(sala002, uniquingKeysWith: +)
// sala001.merge(sala002, uniquingKeysWith: {s1, s2 in s1})
// sala001.merge(sala002, uniquingKeysWith: {s1, s2 in s2})

print(sala001)


var notas = [10, 9, 8, 10]

notas.shuffle()

print(notas)

var nomes = Dictionary(grouping: sala001.keys, by: { $0.prefix(1) })

print(nomes)
