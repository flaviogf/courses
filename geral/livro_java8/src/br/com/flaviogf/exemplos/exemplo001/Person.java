package br.com.flaviogf.exemplos.exemplo001;

public class Person {

    private String firstName;
    private String lastname;

    public Person(String firstName, String lastname) {
        this.firstName = firstName;
        this.lastname = lastname;
    }

    public String getFullName() {
        return this.firstName + " " + this.lastname;
    }
}
