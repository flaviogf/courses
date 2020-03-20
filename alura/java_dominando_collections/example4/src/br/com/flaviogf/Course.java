package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Course {
    private String title;
    private String instructor;
    private List<Lesson> lessons = new ArrayList<>();

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

    public int getDuration() {
        return lessons.stream().mapToInt(Lesson::getTime).sum();
    }

    public void add(Lesson lesson) {
        lessons.add(lesson);
    }

    @Override
    public String toString() {
        return String.format("Course[title=%s, instructor=%s, lessons=%s]", title, instructor, lessons);
    }
}
