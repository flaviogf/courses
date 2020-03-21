package br.com.flaviogf;

import java.util.Collection;
import java.util.HashSet;

public class Program {

    public static void main(String[] args) {
        Collection<String> students = new HashSet<>();

        students.add("Frank");
        students.add("Tank");
        students.add("Nina");
        students.add("Rex");
        students.add("Frank");

        System.out.println(students);

        students.remove("Rex");

        System.out.println(students);

        boolean isFrankInTheStudents = students.contains("Frank");

        System.out.println(isFrankInTheStudents);

        System.out.println(students.size());
    }
}
