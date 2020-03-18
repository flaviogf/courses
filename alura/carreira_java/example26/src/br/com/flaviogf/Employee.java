package br.com.flaviogf;

public abstract class Employee {
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

    public abstract double getBonus();
}
