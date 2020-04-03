package br.com.flaviogf.example6.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Account {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String agency;
    private String number;

    public Account(String agency, String number) {
        this.agency = agency;
        this.number = number;
    }

    public Integer getId() {
        return id;
    }

    public String getAgency() {
        return agency;
    }

    public String getNumber() {
        return number;
    }
}