package br.com.flaviogf;

public class Employee {
    private String name;
    private String document;
    private double salary;

    public Employee(String name, String document, double salary) {
        this.name = name;
        this.document = document;
        this.salary = salary;
    }

    public String getName() {
        return name;
    }

    public String getDocument() {
        return document;
    }

    public double getSalary() {
        return salary;
    }

    public double getBonus() {
        return salary * 0.10;
    }
}
