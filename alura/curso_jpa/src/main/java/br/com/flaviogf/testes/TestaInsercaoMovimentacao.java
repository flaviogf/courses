package br.com.flaviogf.testes;

import br.com.flaviogf.modelo.Conta;
import br.com.flaviogf.modelo.Movimentacao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.math.BigDecimal;
import java.util.Calendar;

public class TestaInsercaoMovimentacao {

    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("cursojpa");
        EntityManager em = emf.createEntityManager();
        Conta conta = new Conta();
        conta.setId(1);
        Movimentacao movimentacao = new Movimentacao();
        movimentacao.setValor(new BigDecimal(100));
        movimentacao.setData(Calendar.getInstance());
        movimentacao.setConta(conta);
        em.getTransaction().begin();
        em.persist(movimentacao);
        em.getTransaction().commit();
        emf.close();
        em.close();
    }
}
