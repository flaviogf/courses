package br.com.flaviogf.exemplos.exemplo006;

import java.util.Arrays;

class Calulador {

    long calcula(int... numeros) {
        return Arrays.stream(numeros).reduce(0, (total, valor) -> total + valor);
    }
}

public class Main {

    public static void main(String... args) {
        System.out.println(new Calulador().calcula(50, 50, 50));
    }
}
