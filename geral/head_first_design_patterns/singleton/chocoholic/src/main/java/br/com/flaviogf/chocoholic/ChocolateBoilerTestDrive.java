package br.com.flaviogf.chocoholic;

public class ChocolateBoilerTestDrive {
    public static void main(String[] args) {
        ChocolateBoiler boiler = ChocolateBoiler.getInstance();
        System.out.println(boiler);

        boiler.fill();
        System.out.println(boiler);

        boiler.boil();
        System.out.println(boiler);

        boiler.drain();
        System.out.println(boiler);
    }
}
