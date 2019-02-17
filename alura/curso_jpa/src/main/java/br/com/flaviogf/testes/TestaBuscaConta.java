package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Conta;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import static java.lang.String.format;

public class TestaBuscaConta {

    public static void main(String[] args) {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        em.createQuery("select distinct c from Conta c left join fetch c.movimentacoes", Conta.class)
                .getResultList()
                .forEach(c -> {
                    System.out.println(format("Conta %s", c.getCliente().getNome()));
                    c.getMovimentacoes().forEach(m -> System.out.println(format("\tMovimentacao %s", m.getValor())));
                });
        em.close();
        emf.close();
    }
}
