package br.com.flaviogf;

public class SavingsAccount extends Account {
    public SavingsAccount(String number, String agency) {
        super(number, agency);
    }

    @Override
    public String toString() {
        return String.format("SavingsAccount(number=%s,agency=%s)", getNumber(), getAgency());
    }
}
