package br.com.flaviogf;

import java.util.ArrayList;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        List<Dog> dogs = new ArrayList<>();

        dogs.add(new Dog("Frank"));
        dogs.add(new Dog("Tank"));

        System.out.println(dogs.contains(new Dog("Frank")));
        System.out.println(dogs.contains(new Dog("Rex")));
    }
}
