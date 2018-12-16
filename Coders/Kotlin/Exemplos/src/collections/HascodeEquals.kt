package collections

class Objeto(val nome: String, val descricacao: String) {

    override fun hashCode(): Int {
        return nome.length
    }

    override fun equals(other: Any?) = if (other is Objeto) nome.equals(other.nome, ignoreCase = true) else false
}

fun main(args: Array<String>) {
    val set = hashSetOf(
            Objeto("Faca", "..."), //Haschode = 4
            Objeto("Cadeira", "..."), //Haschode = 7
            Objeto("Cabo", "...") //Hascode = 4
    )
    set.contains(Objeto("faca", "???")).print()
    val obj1 = Objeto("Faca", "...") //Haschode = 4
    val obj2 = Objeto("faca", "...") //Hascode = 4
    (obj1 == obj2).print() // Verdadeiro us o equals
    (obj1 === obj2).print() // Falso usa o referencia na memoria
}