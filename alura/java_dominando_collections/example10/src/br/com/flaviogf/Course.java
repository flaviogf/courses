package br.com.flaviogf;

import java.util.*;

public class Course {
    private String title;
    private String instructor;
    private Set<Student> students = new HashSet<>();
    private Map<Integer, Student> registrations = new HashMap<>();

    public Course(String title, String instructor) {
        this.title = title;
        this.instructor = instructor;
    }

    public String getTitle() {
        return title;
    }

    public String getInstructor() {
        return instructor;
    }

    public Set<Student> getStudents() {
        return Collections.unmodifiableSet(students);
    }

    @Override
    public String toString() {
        return String.format("Course[title=%s, instructor=%s, students=%s]", title, instructor, students);
    }

    public void register(Student student) {
        students.add(student);
        registrations.put(student.getRegistration(), student);
    }

    public Student getStudent(int registration) {
        return registrations.get(registration);
    }
}
