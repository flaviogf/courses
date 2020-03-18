package br.com.flaviogf;

public class Account {
    double amount;
    String number;
    String agency;
    String holder;

    public void deposit(double value) {
        this.amount += value;
    }

    public boolean withdraw(double value) {
        if (this.amount - value >= 0) {
            this.amount -= value;
            return true;
        }

        return false;
    }
}
