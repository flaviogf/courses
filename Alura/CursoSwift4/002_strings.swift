let nome = "Flavio Garcia Fernandos"

print(nome.count)

nome.forEach {
    print($0, terminator: "-")
}

nome.filter { $0 == "F"}.forEach { print($0, terminator: "-") }

print()
