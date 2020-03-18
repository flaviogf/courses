package br.com.flaviogf;

public class Manager extends Employee {
    public Manager(String name, String document, double salary) {
        super(name, document, salary);
    }

    @Override
    public double getBonus() {
        return 500;
    }
}
