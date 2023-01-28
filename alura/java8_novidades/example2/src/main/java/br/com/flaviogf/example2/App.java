package br.com.flaviogf.example2;

import java.util.ArrayList;

public class App {
  public static void main(String[] args) {
    var courses = new ArrayList<String>();

    courses.add("casa do código");
    courses.add("alura online");
    courses.add("caelum");

    courses.forEach(s -> System.out.println(s));

    courses.sort((s1, s2) -> Integer.compare(s1.length(), s2.length()));

    courses.forEach(s -> System.out.println(s));
  }
}
