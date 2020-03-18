package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Customer customer = new Customer();
        customer.name = "Flavio";

        Account account = new Account();
        account.customer = customer;

        System.out.println(customer.name);
        System.out.println(account.customer.name);
    }
}
