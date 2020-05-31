package br.com.flaviogf.marketplace.repositories;

import br.com.flaviogf.marketplace.models.Product;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;
import java.util.ArrayList;
import java.util.List;

public class ProductRepositoryImpl implements ProductQueryByNameCategoryAndStore {
    @PersistenceContext
    private final EntityManager entityManager;

    public ProductRepositoryImpl(EntityManager entityManager) {
        this.entityManager = entityManager;
    }

    @Override
    public List<Product> findAll(String name, Long categoryId, Long storeId) {
        CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();

        CriteriaQuery<Product> criteriaQuery = criteriaBuilder.createQuery(Product.class);

        Root<Product> root = criteriaQuery.from(Product.class);

        List<Predicate> predicates = new ArrayList<>();

        if (name != null) {
            predicates.add(criteriaBuilder.like(root.get("name"), '%' + name + '%'));
        }

        if (categoryId != null) {
            predicates.add(criteriaBuilder.equal(root.join("categories").get("id"), categoryId));
        }

        if (storeId != null) {
            predicates.add(criteriaBuilder.equal(root.get("store").get("id"), storeId));
        }

        Predicate[] predicatesArray = new Predicate[predicates.size()];

        criteriaQuery.select(root).where(predicates.toArray(predicatesArray));

        TypedQuery<Product> query = entityManager.createQuery(criteriaQuery);

        return query.getResultList();
    }
}
