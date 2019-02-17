package oo.heranca

interface IEsportivo {

    var turbo: Boolean

    fun acionarTurbo() {
        turbo = true
    }

    fun desligarTurbo() {
        turbo = false
    }
}