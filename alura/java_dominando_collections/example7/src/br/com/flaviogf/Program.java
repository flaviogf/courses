package br.com.flaviogf;

import java.util.Set;

public class Program {

    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");

        javaCollections.register(new Student("Frank", 1234));
        javaCollections.register(new Student("Rex", 4321));

        Set<Student> students = javaCollections.getStudents();

        System.out.println(students);
    }
}
