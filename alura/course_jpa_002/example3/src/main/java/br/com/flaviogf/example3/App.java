package br.com.flaviogf.example3;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import br.com.flaviogf.example3.models.Account;

public class App {
    public static void main(String[] args) {
        insert();
        update();
    }

    private static void insert() {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example3");
        EntityManager em = emf.createEntityManager();

        Account frank = new Account();
        frank.setAgency("123");
        frank.setNumber("456");
        frank.setHolder("Frank");
        frank.setBalance(100000);

        em.getTransaction().begin();

        em.persist(frank);

        em.getTransaction().commit();

        emf.close();
    }

    private static void update() {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example3");
        EntityManager em = emf.createEntityManager();

        Account frank = new Account();
        frank.setId(1);
        frank.setAgency("987");
        frank.setNumber("789");
        frank.setHolder("frank");
        frank.setBalance(5000);

        em.getTransaction().begin();

        em.merge(frank);

        em.getTransaction().commit();

        emf.close();
    }
}