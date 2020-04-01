package br.com.flaviogf.testes;

import br.com.flaviogf.dao.MovimentacaoDao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class TestaNamedQuery {

    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        MovimentacaoDao dao = new MovimentacaoDao(em);
        System.out.println(dao.getMedia());
        dao.getMediasPorDia().forEach(System.out::println);
        em.close();
        emf.close();
    }
}
