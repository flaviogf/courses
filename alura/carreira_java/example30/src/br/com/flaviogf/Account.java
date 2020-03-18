package br.com.flaviogf;

public class Account {
    private String number;
    private String agency;
    private double balance;

    public Account(String number, String agency, double balance) {
        this.number = number;
        this.agency = agency;
        this.balance = balance;
    }

    public double getBalance() {
        return balance;
    }

    public void deposit(double value) {
        balance += value;
    }

    public void withdraw(double value) {
        if (balance - value < 0) {
            throw new InsufficientFundsException(String.format("Account has %.2f and was tried to withdraw %.2f", balance, value));
        }

        balance -= value;
    }

    public void transfer(double value, Account to) {
        withdraw(value);
        to.deposit(value);
    }
}
