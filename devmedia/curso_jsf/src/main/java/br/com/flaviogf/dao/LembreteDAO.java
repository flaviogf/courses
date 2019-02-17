package br.com.flaviogf.dao;

import br.com.flaviogf.modelo.Lembrete;

import javax.persistence.EntityManager;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class LembreteDAO {

    private static List<Lembrete> lembretes = new ArrayList<>();

    private EntityManager em;

    public LembreteDAO(EntityManager em) {
        this.em = em;
    }

    public List<Lembrete> lista() {
        return em.createQuery("select l from Lembrete l", Lembrete.class).getResultList();
    }

    public void adiciona(Lembrete lembrete) {
        em.getTransaction().begin();
        em.persist(lembrete);
        em.getTransaction().commit();
    }

    public Optional<Lembrete> busca(Integer id) {
        Lembrete lembrete = em.find(Lembrete.class, id);
        return Optional.of(lembrete);
    }

    public void remove(Lembrete lembrete) {
        em.getTransaction().begin();
        em.remove(lembrete);
        em.getTransaction().commit();
    }

    public void edita(Lembrete lembrete) {
        em.getTransaction().begin();
        em.merge(lembrete);
        em.getTransaction().commit();
    }
}
