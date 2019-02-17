package oo.heranca

class Ferrari(velocidadeMaxima: Int = 200) : Carro(velocidadeMaxima), IEsportivo {

    override var turbo: Boolean = false

    override fun acelerar() {
        super.alterarVelocidade(if (turbo) velocidadeAtual + 50 else velocidadeAtual + 25)
    }

    override fun freiar() {
        super.alterarVelocidade(if (turbo) velocidadeAtual - 50 else velocidadeAtual - 25)
    }

    override fun toString(): String {
        return "Velocidade atual $velocidadeAtual KM/H"
    }

}