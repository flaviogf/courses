package br.com.flaviogf;

public class CheckingAccount extends Account {
    public CheckingAccount(String number, String agency) {
        super(number, agency);
    }

    @Override
    public String toString() {
        return String.format("CheckingAccount(number=%s,agency=%s)", getNumber(), getAgency());
    }
}
