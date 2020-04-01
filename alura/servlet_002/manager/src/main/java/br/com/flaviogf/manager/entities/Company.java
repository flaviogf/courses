package br.com.flaviogf.manager.entities;

import java.util.Date;

public class Company {
    private String id;
    private String name;
    private Date foundationDate;

    public Company(String id, String name, Date foundationDate) {
        this.id = id;
        this.name = name;
        this.foundationDate = foundationDate;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Date getFoundationDate() {
        return foundationDate;
    }
}