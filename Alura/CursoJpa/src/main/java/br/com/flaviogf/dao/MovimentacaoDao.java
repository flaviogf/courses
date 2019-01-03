package br.com.flaviogf.dao;

import javax.persistence.EntityManager;
import java.util.List;

public class MovimentacaoDao {

    private EntityManager em;

    public MovimentacaoDao(EntityManager em) {
        this.em = em;
    }

    public Double getMedia() {
        return em.createNamedQuery("media", Double.class).getSingleResult();
    }

    public List<Double> getMediasPorDia() {
        return em.createNamedQuery("mediaPorDia", Double.class).getResultList();
    }
}
