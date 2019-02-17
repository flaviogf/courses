package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Categoria;
import br.com.flaviogf.modelo.Cliente;
import br.com.flaviogf.modelo.Conta;
import br.com.flaviogf.modelo.Movimentacao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Calendar;

public class PopulaBanco {

    public static void main(String[] args) {

        Cliente cliente = new Cliente();
        cliente.setNome("Fernando");

        Cliente cliente2 = new Cliente();
        cliente2.setNome("Fernando");

        Categoria categoria = new Categoria();
        categoria.setDescricao("compra");

        Categoria categoria2 = new Categoria();
        categoria2.setDescricao("compra");

        Conta conta = new Conta();
        conta.setAgencia("456");
        conta.setNumero("456");
        conta.setCliente(cliente);

        Conta conta2 = new Conta();
        conta2.setAgencia("456");
        conta2.setNumero("456");
        conta2.setCliente(cliente2);

        Movimentacao movimentacao = new Movimentacao();
        movimentacao.setConta(conta);
        movimentacao.setData(Calendar.getInstance());
        movimentacao.setValor(new BigDecimal(1000));
        movimentacao.setCategorias(Arrays.asList(categoria));

        Movimentacao movimentacao2 = new Movimentacao();
        movimentacao2.setConta(conta);
        movimentacao2.setData(Calendar.getInstance());
        movimentacao2.setValor(new BigDecimal(1000));
        movimentacao2.setCategorias(Arrays.asList(categoria));

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        em.persist(cliente);
        em.persist(cliente2);
        em.persist(categoria);
        em.persist(categoria2);
        em.persist(conta);
        em.persist(conta2);
        em.persist(movimentacao);
        em.persist(movimentacao2);
        em.getTransaction().commit();
        em.close();
        emf.close();

    }
}
