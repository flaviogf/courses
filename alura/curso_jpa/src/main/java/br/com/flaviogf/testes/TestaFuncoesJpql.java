package br.com.flaviogf.testes;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.math.BigDecimal;

public class TestaFuncoesJpql {

    public static void main(String[] args) {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();

        BigDecimal soma = em.createQuery("select sum (m.valor) from Movimentacao m", BigDecimal.class)
                .getSingleResult();
        System.out.println(soma);

        Double media = em.createQuery("select avg (m.valor) from Movimentacao m", Double.class)
                .getSingleResult();
        System.out.println(media);

        BigDecimal maior = em.createQuery("select max (m.valor) from Movimentacao m", BigDecimal.class)
                .getSingleResult();
        System.out.println(maior);

        Long total = em.createQuery("select count (m) from Movimentacao m", Long.class)
                .getSingleResult();

        System.out.println(total);

        em.createQuery("select avg(m) from Movimentacao m group by m.data", Double.class)
                .getResultList()
                .forEach(System.out::println);

        em.close();
        emf.close();
    }
}
