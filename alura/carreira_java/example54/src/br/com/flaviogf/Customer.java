package br.com.flaviogf;

import java.io.Serializable;

public class Customer implements Serializable {
    private String name;
    private String document;

    public Customer(String name, String document) {
        this.name = name;
        this.document = document;
    }

    public String getName() {
        return name;
    }

    public String getDocument() {
        return document;
    }
}
