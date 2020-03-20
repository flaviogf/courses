package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        String lesson1 = "Java 8: Tire proveito dos novos recursos da linguagem";
        String lesson2 = "Apache Camel";
        String lesson3 = "Certificacao Java SE 8 Programmer I";

        List<String> lessons = new ArrayList<>();

        lessons.add(lesson1);
        lessons.add(lesson2);
        lessons.add(lesson3);

        lessons.forEach(System.out::println);
        System.out.println();

        lessons.remove(1);

        lessons.forEach(System.out::println);
        System.out.println();

        Collections.sort(lessons);

        lessons.forEach(System.out::println);
        System.out.println();

        String lesson = lessons.get(1);
        System.out.println(lesson);
        System.out.println();

        System.out.println(lessons);
        System.out.println();

        System.out.println(lessons.size());
        System.out.println();
    }
}
