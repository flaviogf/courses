package br.com.flaviogf.alura.models;

import static java.lang.String.format;

public class Course {
    private final int id;
    private final String name;
    private final String category;

    public Course(int id, String name, String category) {
        this.id = id;
        this.name = name;
        this.category = category;
    }

    @Override
    public String toString() {
        return format("Course(name='%s')", this.name);
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getCategory() {
        return category;
    }
}
