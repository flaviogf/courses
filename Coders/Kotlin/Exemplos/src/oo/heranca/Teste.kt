package oo.heranca

import collections.print

fun main(args: Array<String>) {
    val ferrari = Ferrari(250)
    with(ferrari) {
        acionarTurbo()
        for (i in 0..3) acelerar()
        print()
    }
}