package br.com.flaviogf.example4;

import java.math.BigDecimal;
import java.time.LocalDateTime;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import br.com.flaviogf.example4.models.Account;
import br.com.flaviogf.example4.models.ETransition;
import br.com.flaviogf.example4.models.Transition;

public class App {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example4");
        EntityManager em = emf.createEntityManager();

        Account account = new Account();
        account.setAgency("123");
        account.setNumber("123");
        account.setHolder("Frank");

        Transition transition = new Transition();
        transition.setDescription("Payment");
        transition.setDate(LocalDateTime.now());
        transition.setValue(new BigDecimal(555));
        transition.setType(ETransition.Output);
        transition.setAccount(account);

        em.getTransaction().begin();

        em.persist(account);
        em.persist(transition);

        em.getTransaction().commit();

        emf.close();
    }
}