package br.com.flaviogf.example5;

import java.math.BigDecimal;
import java.time.LocalDateTime;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import br.com.flaviogf.example5.models.Account;
import br.com.flaviogf.example5.models.Category;
import br.com.flaviogf.example5.models.Customer;
import br.com.flaviogf.example5.models.Transition;

public class App {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example5");
        EntityManager em = emf.createEntityManager();

        Category category = new Category("Business Trip");

        Account account = new Account("123", "456", new BigDecimal(1000));

        Customer frank = new Customer("Frank", "123", account);

        Transition transition = new Transition("Payment", LocalDateTime.now(), new BigDecimal(500), account);

        transition.add(category);

        em.getTransaction().begin();

        em.persist(category);
        em.persist(account);
        em.persist(frank);
        em.persist(transition);

        em.getTransaction().commit();

        emf.close();
    }
}