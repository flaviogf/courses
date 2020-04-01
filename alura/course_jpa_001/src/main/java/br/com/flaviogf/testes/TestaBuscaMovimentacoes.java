package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Movimentacao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import static java.lang.String.format;

public class TestaBuscaMovimentacoes {

    public static void main(String[] args) {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();

        String jpql = "select m from Movimentacao m where m.valor > 500";
        em.createQuery(jpql, Movimentacao.class)
                .getResultList()
                .forEach(m -> System.out.println(format("Movimentaco %s Valor %.2f", m.getId(), m.getValor())));

        jpql = "select m from Movimentacao m join m.categorias c where c.descricao = :pDescricao";
        em.createQuery(jpql, Movimentacao.class)
                .setParameter("pDescricao", "venda")
                .getResultList()
                .forEach(m -> System.out.println(format("Movimentacao %s Valor %.2f", m.getId(), m.getValor())));

        em.close();
        emf.close();
    }
}
