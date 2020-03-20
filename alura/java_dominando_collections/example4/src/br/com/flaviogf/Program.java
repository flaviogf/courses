package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");

        javaCollections.add(new Lesson("Trabalhando com ArrayList", 21));
        javaCollections.add(new Lesson("Criando uma aula", 20));
        javaCollections.add(new Lesson("Modelando coleções", 24));
        System.out.println(javaCollections.getLessons());

        List<Lesson> lessons = new ArrayList<>(javaCollections.getLessons());
        Collections.sort(lessons);
        System.out.println(lessons);

        int duration = javaCollections.getDuration();
        System.out.println(duration);
    }
}
