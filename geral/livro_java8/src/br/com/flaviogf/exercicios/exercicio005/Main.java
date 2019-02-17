package br.com.flaviogf.exercicios.exercicio005;

public class Main {

    public static void main(String... args) {
        System.out.println("Hello World");
        System.out.println(Main.class.getName());
        for (String arg : args) {
            System.out.println(arg);
        }
    }
}
