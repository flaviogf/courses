package fundamentos.controles

fun main(args: Array<String>) {
    externo@ for (i in 1..10) {
        for (j in 1..20) {
            if (i == 2 && j == 10) break@externo
            println("$i - $j")
        }
    }
    println("Fim")
}