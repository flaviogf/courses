package lambdas

data class Casa(var endereco: String = "", var numero: Int = 0)

fun main(args: Array<String>) {
    val casa = Casa()
    casa.run {
        endereco = "Rua"
        numero = 100
    }
    println(casa)
}