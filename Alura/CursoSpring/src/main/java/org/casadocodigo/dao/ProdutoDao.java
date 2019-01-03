package org.casadocodigo.dao;

import org.casadocodigo.models.Produto;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import java.util.List;

@Repository
@Transactional
public class ProdutoDao {

    @PersistenceContext
    private EntityManager manager;

    public void grava(Produto produto) {
        manager.persist(produto);
    }

    public List<Produto> lista() {
        return manager.createQuery("SELECT p FROM Produto p", Produto.class).getResultList();
    }
}
