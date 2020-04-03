package br.com.flaviogf.example5.models;

import java.math.BigDecimal;

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
    private BigDecimal balance;

    @Deprecated
    public Account() {
    }

    public Account(String agency, String number, BigDecimal balance) {
        this.agency = agency;
        this.number = number;
        this.balance = balance;
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

    public BigDecimal getBalance() {
        return balance;
    }
}