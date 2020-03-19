package br.com.flaviogf;

public class Customer {
    private String name;
    private String document;

    public Customer(String name, String document) {
        this.name = name;
        this.document = document;
    }

    @Override
    public String toString() {
        return String.format("Customer(name=%s, document=%s)", name, document);
    }
}
