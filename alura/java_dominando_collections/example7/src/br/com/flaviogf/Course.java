package br.com.flaviogf;

import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

public class Course {
    private String title;
    private String instructor;
    private Set<Student> students = new HashSet<>();

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

    public void register(Student student) {
        students.add(student);
    }

    @Override
    public String toString() {
        return String.format("Course[title=%s, instructor=%s, students=%s]", title, instructor, students);
    }
}
