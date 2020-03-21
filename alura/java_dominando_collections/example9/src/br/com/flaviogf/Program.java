package br.com.flaviogf;

import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.Set;

public class Program {

    public static void main(String[] args) {
        Set<String> students = new LinkedHashSet<>();

        students.add("Frank");
        students.add("Rex");
        students.add("Nina");
        students.add("Tank");
        students.add("Pit");
        students.add("Frank");

        Iterator<String> iterator = students.iterator();

        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }
    }
}
