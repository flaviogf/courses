package br.com.flaviogf;

import java.util.List;

public class Program {

    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");
        javaCollections.add(new Lesson("Revisando as collection", 21));
        javaCollections.add(new Lesson("Lista de objetos", 15));
        List<Lesson> lessons = javaCollections.getLessons();
        System.out.println(lessons);
    }
}
