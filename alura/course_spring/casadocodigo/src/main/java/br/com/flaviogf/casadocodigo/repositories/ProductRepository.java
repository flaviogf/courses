package br.com.flaviogf.casadocodigo.repositories;

import java.util.List;

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

    public List<Product> all() {
        return em.createQuery("select p from Product p", Product.class).getResultList();
    }

    public Product get(Integer id) {
        return em.createQuery("select p from Product p join fetch p.prices where id = :id", Product.class)
                .setParameter("id", id).getSingleResult();
    }
}
