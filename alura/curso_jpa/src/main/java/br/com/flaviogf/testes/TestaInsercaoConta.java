package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Conta;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class TestaInsercaoConta {

    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        Conta conta = new Conta();
        conta.setAgencia("123");
        conta.setNumero("456");
        conta.setTitular("Fernando");
        em.getTransaction().begin();
        em.persist(conta);
        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}
