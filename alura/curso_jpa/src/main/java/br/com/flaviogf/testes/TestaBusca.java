package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Movimentacao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class TestaBusca {

    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        Movimentacao movimentacao = em.find(Movimentacao.class, 7);
        System.out.println(movimentacao.getConta().getTitular());
        emf.close();
        em.close();
    }
}
