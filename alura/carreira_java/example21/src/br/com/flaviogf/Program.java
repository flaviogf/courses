package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account = new Account();

        account.deposit(100);

        boolean result = account.withdraw(100);

        System.out.println(account.getAmount());

        System.out.println(result);

        Customer customer = new Customer();
        customer.setName("Flavio");

        account.setCustomer(customer);

        System.out.println(account.getCustomer().getName());
    }
}
