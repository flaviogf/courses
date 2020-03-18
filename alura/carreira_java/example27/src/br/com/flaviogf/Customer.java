package br.com.flaviogf;

public class Customer implements CanAuthenticate {
    private String name;
    private String password;

    public Customer(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    @Override
    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public boolean authenticate(String password) {
        return this.password.equals(password);
    }
}
