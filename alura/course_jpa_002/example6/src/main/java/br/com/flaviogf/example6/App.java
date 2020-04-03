package br.com.flaviogf.example6;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.TypedQuery;

import br.com.flaviogf.example6.models.Account;
import br.com.flaviogf.example6.models.Transition;

public class App {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example6");
        EntityManager em = emf.createEntityManager();

        Account account = new Account("123", "456");

        Transition transition = new Transition("Business Trip", LocalDateTime.now(), new BigDecimal(1000), account);

        em.getTransaction().begin();

        em.persist(account);
        em.persist(transition);

        em.getTransaction().commit();

        String jpql = "select t from Transition t where t.account = :account";

        TypedQuery<Transition> query = em.createQuery(jpql, Transition.class);

        query.setParameter("account", account);

        List<Transition> transitions = query.getResultList();

        transitions.stream().forEach(System.out::println);

        emf.close();
    }
}