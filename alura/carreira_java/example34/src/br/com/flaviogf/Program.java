package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        println(1);
        println("Hello World");
        println(new Customer("Frank", "123"));
    }

    public static void println(Object obj) {
        System.out.println(obj);
    }
}
