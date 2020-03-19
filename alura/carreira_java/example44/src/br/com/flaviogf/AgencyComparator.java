package br.com.flaviogf;

import java.util.Comparator;

public class AgencyComparator implements Comparator<Account> {
    @Override
    public int compare(Account account1, Account account2) {
        return account1.getAgency().compareTo(account2.getAgency());
    }
}
