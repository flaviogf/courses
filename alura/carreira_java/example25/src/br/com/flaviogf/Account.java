package br.com.flaviogf;

public class Account {
    private String number;
    private String agency;
    private double amount;

    public Account(String number, String agency, double amount) {
        this.number = number;
        this.agency = agency;
        this.amount = amount;
    }

    public String getNumber() {
        return number;
    }

    public String getAgency() {
        return agency;
    }

    public double getAmount() {
        return amount;
    }

    public void deposit(double value) {
        amount += value;
    }

    public boolean withdraw(double value) {
        if (amount - value < 0) {
            return false;
        }

        amount -= value;

        return true;
    }

    public boolean transfer(double value, Account to) {
        if (!withdraw(value)) {
            return false;
        }

        to.deposit(value);

        return true;
    }
}
