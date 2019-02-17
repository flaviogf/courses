package br.com.alura.financas.extension

import java.text.SimpleDateFormat
import java.util.*

data class Horario(val dia: Int, val mes: Int, val ano: Int)

fun Calendar.formataParaBrasileiro(): String {
    val formatoBrasileiro = "dd/MM/yyyy"
    val format = SimpleDateFormat(formatoBrasileiro)
    return format.format(this.time)
}

fun Calendar.extrairDataAtual(): Horario {
    val dia = this.get(Calendar.DAY_OF_MONTH)
    val mes = this.get(Calendar.MONTH)
    val ano = this.get(Calendar.YEAR)
    return Horario(dia, mes, ano)
}
