package br.com.flaviogf;

public class Student {
    private String name;
    private int registration;

    public Student(String name, int registration) {
        this.name = name;
        this.registration = registration;
    }

    public String getName() {
        return name;
    }

    public int getRegistration() {
        return registration;
    }

    @Override
    public String toString() {
        return String.format("Student[name=%s, registration=%04d]", name, registration);
    }
}
