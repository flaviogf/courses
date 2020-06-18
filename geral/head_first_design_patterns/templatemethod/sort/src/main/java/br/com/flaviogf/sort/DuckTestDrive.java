package br.com.flaviogf.sort;

import java.util.Arrays;
import java.util.stream.Stream;

public class DuckTestDrive {
    public static void main(String[] args) {
        Duck[] ducks = {
                new Duck("Daffy", 8.0),
                new Duck("Dewey", 2.0),
                new Duck("Howard", 7.0),
                new Duck("Louie", 2.0),
                new Duck("Donald", 10.0),
                new Duck("Huey", 2.0),
        };

        System.out.println("Before sorting:");
        Stream.of(ducks).forEach(System.out::println);

        Arrays.sort(ducks);

        System.out.println("After sorting:");
        Stream.of(ducks).forEach(System.out::println);
    }
}
