package br.com.flaviogf.algamoneyapi.exceptions;

public abstract class AlgaMoneyException extends RuntimeException {
    public AlgaMoneyException(String message) {
        super(message);
    }

    public abstract String getMessageSource();
}
