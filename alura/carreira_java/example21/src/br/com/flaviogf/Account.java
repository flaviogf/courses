package br.com.flaviogf;

public class Account {
    private double amount;
    private String number;
    private String agency;
    private Customer customer;

    public double getAmount() {
        return amount;
    }

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public String getAgency() {
        return agency;
    }

    public void setAgency(String agency) {
        this.agency = agency;
    }

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public void deposit(int value) {
        this.amount += value;
    }

    public boolean withdraw(int value) {
        if (this.amount - value < 0) {
            return false;
        }

        this.amount += value;

        return true;
    }
}
