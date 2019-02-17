package oo.heranca

open class Carro(val velocidadeMaxima: Int, var velocidadeAtual: Int = 0) {

    protected fun alterarVelocidade(novaVelocidade: Int) {
        velocidadeAtual = when (novaVelocidade) {
            in 0..velocidadeMaxima -> novaVelocidade
            in velocidadeMaxima + 1..Int.MAX_VALUE -> velocidadeMaxima
            else -> 0
        }
    }

    open fun acelerar() {
        alterarVelocidade(velocidadeAtual + 5)
    }

    open fun freiar() {
        alterarVelocidade(velocidadeAtual - 5)
    }
}