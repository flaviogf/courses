package br.com.flaviogf.manager;

public class Company {
    private String id;
    private String name;

    public Company(String id, String name) {
        this.id = id;
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
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
