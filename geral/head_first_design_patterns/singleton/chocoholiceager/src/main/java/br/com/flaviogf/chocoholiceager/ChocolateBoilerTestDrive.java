package br.com.flaviogf.chocoholiceager;

public class ChocolateBoilerTestDrive {
    public static void main(String[] args) throws InterruptedException {
        Thread thread1 = new Thread(ChocolateBoilerTestDrive::run);
        Thread thread2 = new Thread(ChocolateBoilerTestDrive::run);

        thread1.start();
        thread2.start();

        thread1.join();
        thread2.join();
    }

    private static void run() {
        ChocolateBoiler boiler = ChocolateBoiler.getInstance();
        System.out.println(boiler);

        boiler.fill();
        System.out.println(boiler);
    }
}
