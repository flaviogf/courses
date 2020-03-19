package br.com.flaviogf;

import java.util.Objects;

public class Dog {
    private String name;

    public Dog(String name) {
        this.name = name;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }

        if (getClass() != obj.getClass()) {
            return false;
        }

        Dog dog = (Dog) obj;

        return name.equals(dog.name);
    }

    @Override
    public int hashCode() {
        return Objects.hashCode(name);
    }
}
