package br.com.flaviogf;

public class Account {
    double amount;
    String number;
    String agency;
    String holder;

    public void deposit(double value) {
        this.amount += value;
    }
}
