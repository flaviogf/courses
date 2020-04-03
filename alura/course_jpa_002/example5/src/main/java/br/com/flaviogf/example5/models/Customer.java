package br.com.flaviogf.example5.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;

@Entity
public class Customer {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String name;
    private String document;
    @OneToOne
    private Account account;

    @Deprecated
    public Customer() {
    }

    public Customer(String name, String document, Account account) {
        this.name = name;
        this.document = document;
        this.account = account;
    }

    public String getName() {
        return name;
    }

    public String getDocument() {
        return document;
    }

    public Account getAccount() {
        return account;
    }
}