package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Categoria;
import br.com.flaviogf.modelo.Movimentacao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.util.Arrays;

public class TestaInsercaoMovimentaoComCategoria {

    public static void main(String[] args) {
        Categoria categoria = new Categoria();
        categoria.setDescricao("teste1");

        Categoria categoria2 = new Categoria();
        categoria2.setDescricao("teste 2");

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();

        Movimentacao movimentacao = em.find(Movimentacao.class, 1);
        movimentacao.setCategorias(Arrays.asList(categoria, categoria2));

        em.getTransaction().begin();

        em.persist(categoria);
        em.persist(categoria2);
        em.persist(movimentacao);

        em.getTransaction().commit();
        emf.close();
        em.close();
    }
}
