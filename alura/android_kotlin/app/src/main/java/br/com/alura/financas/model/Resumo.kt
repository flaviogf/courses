package br.com.alura.financas.model

import java.math.BigDecimal

class Resumo(private val transacoes: List<Transacao>) {

    val receita
        get() = transacoes
                .filter { it.tipo == Tipo.RECEITA }
                .sumByDouble { it.valor.toDouble() }
                .let { BigDecimal(it) }

    val despesa
        get() = transacoes
                .filter { it.tipo == Tipo.DESPESA }
                .sumByDouble { it.valor.toDouble() }
                .let { BigDecimal(it) }

    val total: BigDecimal
        get() = receita.subtract(despesa)
}