package funcoes

import java.util.*

data class Horario(var hora: Int, var minutos: Int, var segundos: Int)

fun agora(): Horario {
    val agora = Calendar.getInstance()
    with(agora) {
        return Horario(get(Calendar.HOUR), get(Calendar.MINUTE), get(Calendar.SECOND))
    }
}

fun main(args: Array<String>) {
    val (h, m, s) = agora()
    println("$h:$m:$s")
}