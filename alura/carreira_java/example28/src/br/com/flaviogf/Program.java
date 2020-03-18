package br.com.flaviogf;

import java.util.Random;

public class Program {

    public static void main(String[] args) {
        try {
            work();
        } catch (ArithmeticException | NullPointerException ex) {
            ex.printStackTrace();
        }
    }

    public static void work() {
        Work[] works = {
                () -> {
                    throw new ArithmeticException();
                },
                () -> {
                    throw new NullPointerException();
                }
        };

        Random random = new Random();

        int index = random.nextInt(2);

        works[index].invoke();
    }
}
