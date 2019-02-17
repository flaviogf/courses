package modelo

import java.util.*

enum class TabuleiroEvento { VITORIA, DERROTA }

data class Tabuleiro(val qtdLinhas: Int, val qtdColunas: Int, private val qtdMinas: Int) {

    private val campos = mutableListOf<MutableList<Campo>>()
    private val callbacks = mutableListOf<(TabuleiroEvento) -> Unit>()

    init {
        gerarCampos()
        associarVizinhos()
        sortearMinas()
    }

    private fun gerarCampos() {
        for (linha in 0 until qtdLinhas) {
            campos.add(mutableListOf())
            for (coluna in 0 until qtdColunas) {
                val novoCampo = Campo(linha, coluna)
                novoCampo.onEvento(this::verificarDerrotaOuVitoria)
                campos[linha].add(novoCampo)
            }
        }
    }

    private fun associarVizinhos() {
        forEachCampo { associarVizinhos(it) }
    }

    private fun associarVizinhos(campo: Campo) {
        val (linha, coluna) = campo
        val linhas = arrayOf(linha - 1, linha, linha + 1)
        val colunas = arrayOf(coluna - 1, coluna, coluna + 1)
        linhas.forEach { l ->
            colunas.forEach { c ->
                val atual = campos.getOrNull(l)?.getOrNull(c)
                atual?.takeIf { it != campo }?.let { campo.addVizinho(it) }
            }
        }
    }

    private fun sortearMinas() {
        val gerador = Random()
        var qtdMinasAtual = 0
        while (qtdMinasAtual < qtdMinas) {
            val linhaSorteada = gerador.nextInt(qtdLinhas)
            val colunaSorteada = gerador.nextInt(qtdColunas)
            val campoSorteado = campos[linhaSorteada][colunaSorteada]
            if (campoSorteado.seguro) {
                campoSorteado.minar()
                qtdMinasAtual++
            }
        }
    }

    private fun objetivoAlcancado(): Boolean {
        var jogadorGanhou = true
        forEachCampo { if (!it.objetivoAlcancado) jogadorGanhou = false }
        return jogadorGanhou
    }

    private fun verificarDerrotaOuVitoria(campo: Campo, evento: CampoEvento) {
        if (evento == CampoEvento.EXPLOSAO) {
            callbacks.forEach { it(TabuleiroEvento.DERROTA) }
        } else if (objetivoAlcancado()) {
            callbacks.forEach { it(TabuleiroEvento.VITORIA) }
        }
    }

    fun forEachCampo(callback: (Campo) -> Unit) {
        campos.forEach { linha -> linha.forEach(callback) }
    }

    fun onEvento(callback: (TabuleiroEvento) -> Unit) {
        callbacks.add(callback)
    }

    fun reiniciar() {
        forEachCampo { it.reiniciar() }
        sortearMinas()
    }
}