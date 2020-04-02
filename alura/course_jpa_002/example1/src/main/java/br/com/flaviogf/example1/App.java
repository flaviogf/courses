package br.com.flaviogf.example1;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import br.com.flaviogf.example1.models.Account;

public class App {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example1");
        EntityManager em = emf.createEntityManager();

        Account frank = new Account();
        frank.setAgency("123");
        frank.setNumber("456");
        frank.setHolder("Frank");

        em.getTransaction().begin();

        em.persist(frank);

        em.getTransaction().commit();

        emf.close();
    }
}
