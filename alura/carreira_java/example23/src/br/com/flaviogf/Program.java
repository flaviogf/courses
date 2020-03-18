package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Employee employee = new Employee("Fernando", "123", 1000);
        Employee manager = new Manager("Flavio", "345", 1000);

        System.out.println(employee.getBonus());
        System.out.println(manager.getBonus());
    }
}
