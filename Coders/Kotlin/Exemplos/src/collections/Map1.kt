package collections

fun main(args: Array<String>) {
    val map = HashMap<Long, String>()
    map.set(10020030010, "Flávio")
    map.set(40050060020, "Fernando")
    map[70080090030] = "Fatima"

    // for in map ou for in map.entries
    for (par in map) {
        println(par)
    }

    for (nome in map.values) {
        println(nome)
    }

    for (cpf in map.keys) {
        println(cpf)
    }

    for ((cpf, nome) in map) {
        println("$nome (CPF: $cpf)")
    }
}