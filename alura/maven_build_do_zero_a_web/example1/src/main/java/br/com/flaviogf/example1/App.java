package br.com.flaviogf.example1;

import com.thoughtworks.xstream.XStream;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class App {
    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");

        javaCollections.add(new Lesson("Trabalhando com ArrayList", 25));
        javaCollections.add(new Lesson("Listas de objetos", 20));
        javaCollections.add(new Lesson("Relacionamentos com coleções", 15));
        javaCollections.register(new Student("Frank", 1));
        javaCollections.register(new Student("Tank", 2));
        System.out.println(javaCollections);

        ArrayList<Lesson> lessonsOrderedByTime = new ArrayList<>(javaCollections.getLessons());
        Collections.sort(lessonsOrderedByTime, Comparator.comparing(Lesson::getTime));
        System.out.println(lessonsOrderedByTime);

        ArrayList<Lesson> lessonsOrderedByTitle = new ArrayList<>(javaCollections.getLessons());
        Collections.sort(lessonsOrderedByTitle);
        System.out.println(lessonsOrderedByTitle);

        Student frank = javaCollections.getStudent(1);
        System.out.println(frank);

        XStream xstream = new XStream();
        String xml = xstream.toXML(frank);
        System.out.println(xml);
    }
}
