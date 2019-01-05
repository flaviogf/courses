var numero = 0

repeat {
    numero = Int.random(in: 0...100)
    print(numero)
} while numero != 87

var ativo = false

print(ativo)

ativo.toggle()

print(ativo)
