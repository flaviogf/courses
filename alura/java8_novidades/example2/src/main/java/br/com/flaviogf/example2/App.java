package br.com.flaviogf.example2;

import java.util.ArrayList;
import java.util.Arrays;

public class App {
  public static void main(String[] args) {
    var t1 = new Thread(() -> execute("Thread 1"));
    var t2 = new Thread(() -> execute("Thread 2"));

    var threads = Arrays.asList(t1, t2);

    threads.forEach(t -> t.start());

    threads.forEach(t -> {
      try {
        t.join();
      } catch (InterruptedException e) {
      }
    });
  }

  private static void execute(String name) {
    var courses = new ArrayList<String>();

    courses.add("casa do código");
    courses.add("alura online");
    courses.add("caelum");

    System.out.println(name);
    courses.forEach(s -> System.out.println(s));

    courses.sort((s1, s2) -> Integer.compare(s1.length(), s2.length()));

    System.out.println(name);
    courses.forEach(s -> System.out.println(s));
  }
}
