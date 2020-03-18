package br.com.flaviogf;

public class Manager extends Employee implements CanAuthenticate {
    private String password;

    public Manager(String name, String document, double salary) {
        super(name, document, salary);
    }

    @Override
    public double getBonus() {
        return 500;
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
