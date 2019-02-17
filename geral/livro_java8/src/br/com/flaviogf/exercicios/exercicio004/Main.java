package br.com.flaviogf.exercicios.exercicio004;

import java.io.File;
import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        ArrayList<String> existe = new ArrayList<>();

        for (String arg : args) {
            if (new E().existe(arg)) {
                existe.add(arg);
            }
        }
    }
}


class E {

    public boolean existe(String name) {
        File file = new File(name);
        return file.exists();
    }
}
