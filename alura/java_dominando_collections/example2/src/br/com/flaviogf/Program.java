package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        Lesson lesson1 = new Lesson("Revisitando as collections", 21);
        Lesson lesson2 = new Lesson("Lista de objetos", 20);
        Lesson lesson3 = new Lesson("Relacionamento de listas e objetos", 15);

        List<Lesson> lessons = new ArrayList<>();
        lessons.add(lesson1);
        lessons.add(lesson2);
        lessons.add(lesson3);

        System.out.println(lessons);

        Collections.sort(lessons);

        System.out.println(lessons);

        Collections.sort(lessons, Comparator.comparingInt(Lesson::getTime));

        System.out.println(lessons);
    }
}
