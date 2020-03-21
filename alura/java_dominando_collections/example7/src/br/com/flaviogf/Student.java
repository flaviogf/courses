package br.com.flaviogf;

public class Student {
    private String name;
    private int membership;

    public Student(String name, int membership) {
        this.name = name;
        this.membership = membership;
    }

    public String getName() {
        return name;
    }

    public int getMembership() {
        return membership;
    }

    @Override
    public String toString() {
        return String.format("Student[name=%s, membership=%04d]", name, membership);
    }
}
