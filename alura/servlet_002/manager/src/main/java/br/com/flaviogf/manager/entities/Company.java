package br.com.flaviogf.manager.entities;

import java.util.Date;

public class Company {
    private String id;
    private String name;
    private Date date;

    public Company(String id, String name, Date date) {
        this.id = id;
        this.name = name;
        this.date = date;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Date getDate() {
        return date;
    }
}