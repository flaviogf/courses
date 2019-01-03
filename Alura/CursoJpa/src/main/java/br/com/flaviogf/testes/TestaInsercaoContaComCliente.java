package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Cliente;
import br.com.flaviogf.modelo.Conta;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class TestaInsercaoContaComCliente {

    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();

        Cliente cliente = new Cliente();
        cliente.setNome("Flavio");

        Conta conta = new Conta();
        conta.setNumero("123");
        conta.setAgencia("123");
        conta.setTitular(cliente.getNome());
        conta.setCliente(cliente);

        em.getTransaction().begin();
        em.persist(cliente);
        em.persist(conta);
        em.getTransaction().commit();

        emf.close();
        em.close();
    }
}
