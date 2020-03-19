package br.com.flaviogf;

import java.util.ArrayList;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        List<String> dogs = new ArrayList<>();

        dogs.add("Frank");
        dogs.add("Tank");

        for (String dog : dogs) {
            System.out.println(dog);
        }

        System.out.println(dogs.size());
    }
}
