package br.com.flaviogf;

public abstract class Account {
    private String number;
    private String agency;

    public Account(String number, String agency) {
        this.number = number;
        this.agency = agency;
    }

    public String getNumber() {
        return number;
    }

    public String getAgency() {
        return agency;
    }

    @Override
    public String toString() {
        return String.format("Account(number=%s,agency=%s)", number, agency);
    }
}
