package br.com.flaviogf.schedule.models;

import androidx.annotation.NonNull;

public class Student {
    private final String name;
    private final String email;
    private final String phone;

    public Student(String name, String email, String phone) {
        this.name = name;
        this.email = email;
        this.phone = phone;
    }

    @NonNull
    @Override
    public String toString() {
        return name;
    }
}
