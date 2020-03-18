package br.com.flaviogf;

/**
 * It represents a customer
 *
 * @author Flavio
 */
public class Customer {
    private String name;
    private String document;

    /**
     *
     * @param name customer name.
     * @param document customer document.
     */
    public Customer(String name, String document) {
        this.name = name;
        this.document = document;
    }

    public String getName() {
        return name;
    }

    public String getDocument() {
        return document;
    }
}
