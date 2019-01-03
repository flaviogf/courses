package br.com.flaviogf.dao;

import br.com.flaviogf.modelo.Livro;

import javax.inject.Inject;
import javax.persistence.EntityManager;
import java.util.List;

public class LivroDAO {

    @Inject
    private EntityManager em;

    public List<Livro> lista() {
        return em.createQuery("select l from Livro l", Livro.class).getResultList();
    }

    public void salva(Livro livro) {
        em.getTransaction().begin();
        em.persist(livro);
        em.getTransaction().commit();
    }
}
