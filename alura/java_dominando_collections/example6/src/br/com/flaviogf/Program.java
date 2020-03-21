package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;

public class Program {

    public static void main(String[] args) throws InterruptedException {
        Thread thread1 = new Thread(Program::usingList);
        Thread thread2 = new Thread(Program::usingSet);

        thread1.start();
        thread2.start();

        thread1.join();
        thread2.join();
    }

    private static void usingList() {
        Collection<Integer> numbers = new ArrayList<>();

        long begin = System.currentTimeMillis();

        for (int i = 0; i < 50_000; i++) {
            numbers.add(i);
        }

        for (int number : numbers) {
            numbers.contains(number);
        }

        long end = System.currentTimeMillis();

        System.out.println(String.format("List: %d ms", end - begin));
    }

    private static void usingSet() {
        Collection<Integer> numbers = new HashSet<>();

        long begin = System.currentTimeMillis();

        for (int i = 0; i < 50_000; i++) {
            numbers.add(i);
        }

        for (int number : numbers) {
            numbers.contains(number);
        }

        long end = System.currentTimeMillis();

        System.out.println(String.format("Set: %d ms", end - begin));
    }
}
