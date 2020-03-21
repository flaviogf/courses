package br.com.flaviogf;

import java.util.Set;

public class Program {

    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");

        javaCollections.register(new Student("Frank", 1));
        javaCollections.register(new Student("Nina", 2));

        Set<Student> students = javaCollections.getStudents();

        System.out.println(students);

        Student frank = javaCollections.getStudent(1);
        Student nina = javaCollections.getStudent(2);

        System.out.println(frank);
        System.out.println(nina);
    }
}
