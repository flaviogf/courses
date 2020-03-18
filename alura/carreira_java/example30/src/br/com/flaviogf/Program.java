package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account1 = new Account("123", "1", 1000);
        Account account2 = new Account("345", "1", 1000);

        try {
            account1.transfer(500, account2);
            account1.transfer(500, account2);
            account1.transfer(500, account2);
        } catch (InsufficientFundsException ex) {
            ex.printStackTrace();
        }

        System.out.println(account1.getBalance());
        System.out.println(account2.getBalance());
    }
}
