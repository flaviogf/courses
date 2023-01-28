package br.com.flaviogf.example1;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.function.Consumer;

public class App {
  public static void main(String[] args) {
    var courses = new ArrayList<String>();

    courses.add("alura online");
    courses.add("casa do código");
    courses.add("caelum");

    print(courses);

    Collections.sort(courses);

    print(courses);

    Collections.sort(courses, new StringLengthComparator());

    print(courses);

    courses.sort(new StringLengthComparator());

    print(courses);
  }

  private static void print(ArrayList<String> courses) {
    System.out.println("courses:");

    courses.forEach(new StringConsumer());

    System.out.println();
  }
}

class StringLengthComparator implements Comparator<String> {
  @Override
  public int compare(String o1, String o2) {
    return Integer.compare(o1.length(), o2.length());
  }
}

class StringConsumer implements Consumer<String> {
  @Override
  public void accept(String t) {
    System.out.println(t);
  }
}
