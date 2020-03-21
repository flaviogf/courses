package br.com.flaviogf.example1;

import java.util.*;

public class Course {
    private String title;
    private String instructor;
    private List<Lesson> lessons = new ArrayList<>();
    private Set<Student> students = new LinkedHashSet<>();
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

    public List<Lesson> getLessons() {
        return Collections.unmodifiableList(lessons);
    }

    public Set<Student> getStudents() {
        return Collections.unmodifiableSet(students);
    }

    public void add(Lesson lesson) {
        lessons.add(lesson);
    }

    public void register(Student student) {
        registrations.put(student.getRegistration(), student);
        students.add(student);
    }

    public Student getStudent(int registration) {
        return registrations.get(registration);
    }

    @Override
    public String toString() {
        return String.format("Course[title=%s, instructor=%s, lessons=%s, students=%s]", title, instructor, lessons, students);
    }
}
