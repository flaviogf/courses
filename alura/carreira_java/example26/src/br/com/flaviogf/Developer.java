package br.com.flaviogf;

public class Developer extends Employee {
    public Developer(String name, String document, double salary) {
        super(name, document, salary);
    }

    @Override
    public double getBonus() {
        return 1000;
    }
}
