package br.com.flaviogf.algamoneyapi.exceptions;

public class PersonInactiveException extends AlgaMoneyException {
    public PersonInactiveException(String message) {
        super(message);
    }

    @Override
    public String getMessageSource() {
        return "message.error.person-inactive";
    }
}
