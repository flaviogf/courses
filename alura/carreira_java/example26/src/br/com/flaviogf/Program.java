package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Employee employee1 = new Manager("Fernando", "123", 1000);
        Employee employee2 = new Developer("Frank", "456", 1000);

        System.out.println(employee1.getBonus());
        System.out.println(employee2.getBonus());
    }
}
