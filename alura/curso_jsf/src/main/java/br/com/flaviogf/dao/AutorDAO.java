package br.com.flaviogf.dao;

import br.com.flaviogf.modelo.Autor;

import javax.inject.Inject;
import javax.persistence.EntityManager;
import java.util.List;

public class AutorDAO {

    @Inject
    private EntityManager em;

    public List<Autor> lista() {
        return em.createQuery("select a from Autor  a", Autor.class).getResultList();
    }

    public void salva(Autor autor) {
        em.getTransaction().begin();
        em.persist(autor);
        em.getTransaction().commit();
    }
}
