package br.com.flaviogf.example3;

public class App {
    public static void main(String[] args) {
        Product ps3 = new Product("PS3", 1500);
        System.out.println(ps3.getName());
        System.out.println(ps3.getPrice());
    }
}
