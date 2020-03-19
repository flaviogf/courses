package br.com.flaviogf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Program {

    public static void main(String[] args) {
        List<Account> accounts = new ArrayList<>();

        Account account1 = new Account("123", "1", 1000);
        Account account2 = new Account("456", "2", 5000);
        Account account3 = new Account("789", "2", 750);
        Account account4 = new Account("987", "3", 2000);
        Account account5 = new Account("654", "1", 250);
        Account account6 = new Account("321", "2", 500);
        Account account7 = new Account("000", "3", 750);
        Account account8 = new Account("999", "3", 2000);
        Account account9 = new Account("111", "1", 250);

        accounts.add(account1);
        accounts.add(account2);
        accounts.add(account3);
        accounts.add(account4);
        accounts.add(account5);
        accounts.add(account6);
        accounts.add(account7);
        accounts.add(account8);
        accounts.add(account9);

        accounts.sort(new AgencyComparator());

        for (Account account : accounts) {
            System.out.println(account);
        }

        System.out.println();

        Collections.sort(accounts);

        for (Account account : accounts) {
            System.out.println(account);
        }

        System.out.println();

        accounts.sort(new Comparator<Account>() {
            @Override
            public int compare(Account account1, Account account2) {
                return Double.compare(account1.getBalance(), account2.getBalance());
            }
        });

        for (Account account : accounts) {
            System.out.println(account);
        }

        System.out.println();

        accounts.sort((c1, c2) -> c1.getAgency().compareTo(c2.getAgency()));

        for (Account account : accounts) {
            System.out.println(account);
        }
    }
}
