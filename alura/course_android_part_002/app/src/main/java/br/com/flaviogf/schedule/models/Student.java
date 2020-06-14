package br.com.flaviogf.schedule.models;

import androidx.annotation.NonNull;

import java.util.Objects;
import java.util.UUID;

public class Student {
    private final UUID id;
    private final String name;
    private final String email;
    private final String phone;

    public Student(UUID id, String name, String email, String phone) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.phone = phone;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Student student = (Student) o;
        return id.equals(student.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }

    @NonNull
    @Override
    public String toString() {
        return name;
    }
}
