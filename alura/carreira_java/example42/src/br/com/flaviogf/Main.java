package br.com.flaviogf;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        linkedList();
        arrayList();
    }

    private static void linkedList() {
        List<String> dogs = new LinkedList<>();

        dogs.add("Frank");
        dogs.add("Rex");
        dogs.add("Nina");

        for (String dog : dogs) {
            System.out.println(dog);
        }
        dogs.remove("Frank");

        for (String dog : dogs) {
            System.out.println(dog);
        }
    }

    private static void arrayList() {
        List<String> dogs = new ArrayList<>();

        dogs.add("Frank");
        dogs.add("Rex");
        dogs.add("Nina");

        for (String dog : dogs) {
            System.out.println(dog);
        }
        dogs.remove("Frank");

        for (String dog : dogs) {
            System.out.println(dog);
        }
    }
}
