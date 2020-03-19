package br.com.flaviogf;

public class Account implements Comparable<Account> {
    private String number;
    private String agency;
    private double balance;

    public Account(String number, String agency, double balance) {
        this.number = number;
        this.agency = agency;
        this.balance = balance;
    }

    public String getNumber() {
        return number;
    }

    public String getAgency() {
        return agency;
    }

    public double getBalance() {
        return balance;
    }

    @Override
    public String toString() {
        return String.format("Account(number=%s, agency=%s, balance=%.2f)", number, agency, balance);
    }

    @Override
    public int compareTo(Account account) {
        return Double.compare(balance, account.getBalance());
    }
}
