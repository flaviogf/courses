package br.com.flaviogf.produces;

import javax.enterprise.context.ApplicationScoped;
import javax.enterprise.inject.Disposes;
import javax.enterprise.inject.Produces;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import static java.lang.String.format;

public class EntityManagerProduces {

    @Produces
    @ApplicationScoped
    public EntityManagerFactory getEntityManagerFactory() {
        return Persistence.createEntityManagerFactory("livraria-postgres");
    }

    @Produces
    private EntityManager getEntityManger(EntityManagerFactory emf) {
        return emf.createEntityManager();
    }

    private void finaliza(@Disposes EntityManager em) {
        if (!em.isOpen()) return;
        Object banco = em.getEntityManagerFactory().getProperties().get("javax.persistence.jdbc.url");
        System.out.println(format("Fechando conexao com o banco: %s", banco));
        em.close();
    }
}
