package br.com.flaviogf.manager;

import java.util.Date;

public class Company {
    private final String id;
    private final String name;
    private final Date date;

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

    @Override
    public boolean equals(Object obj) {
        if (obj == null) return false;

        if (getClass() != obj.getClass()) return false;

        Company company = (Company) obj;

        return id.equals(company.id);
    }

    @Override
    public int hashCode() {
        return id.hashCode();
    }
}
