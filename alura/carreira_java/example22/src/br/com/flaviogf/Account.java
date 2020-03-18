package br.com.flaviogf;

public class Account {
    private double amount;
    private String number;
    private String agency;

    public Account(String number, String agency) {
        this.number = number;
        this.agency = agency;
    }

    public double getAmount() {
        return amount;
    }

    public String getNumber() {
        return number;
    }

    public String getAgency() {
        return agency;
    }

    public void deposit(double value) {
        this.amount += value;
    }

    public boolean withdraw(double value) {
        if (this.amount - value < 0) {
            return false;
        }

        this.amount -= value;

        return true;
    }
}
