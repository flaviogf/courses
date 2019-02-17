package br.com.flaviogf.exemplos.exemplo005;

class B {
    int c;

    void c(int c) {
        c = c;
    }
}

public class Main {

    public static void main(String... args) {
        B b = new B();
        b.c = 20;
        b.c(50);
        System.out.println(b.c);
    }
}
