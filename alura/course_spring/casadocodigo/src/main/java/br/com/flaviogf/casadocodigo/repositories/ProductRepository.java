package br.com.flaviogf.casadocodigo.repositories;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import br.com.flaviogf.casadocodigo.models.Product;

@Repository
@Transactional
public class ProductRepository {
    @PersistenceContext
    private EntityManager em;

    public void add(Product product) {
        em.persist(product);
    }
}
