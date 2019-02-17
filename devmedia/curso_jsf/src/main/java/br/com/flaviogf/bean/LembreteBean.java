package br.com.flaviogf.bean;

import br.com.flaviogf.dao.LembreteDAO;
import br.com.flaviogf.modelo.Lembrete;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.util.List;

import static br.com.flaviogf.utils.BeanUtils.exibeMensagem;

@ManagedBean
@ViewScoped
public class LembreteBean {

    private LembreteDAO lembreteDAO;

    private Lembrete lembrete;

    @PostConstruct
    public void inicializa() {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("lembretes");
        lembreteDAO = new LembreteDAO(emf.createEntityManager());
        lembrete = new Lembrete();
    }

    public List<Lembrete> getLembretes() {
        return lembreteDAO.lista();
    }

    public Lembrete getLembrete() {
        return lembrete;
    }

    public void buscaPorId() {
        lembrete = lembreteDAO.busca(lembrete.getId()).orElse(new Lembrete());
    }

    public String adiciona() {
        lembreteDAO.adiciona(lembrete);
        lembrete = new Lembrete();
        exibeMensagem("Lembrete adicionado");
        return "home";
    }

    public String remove() {
        lembreteDAO.remove(lembrete);
        lembrete = new Lembrete();
        exibeMensagem("Lembrete removido com sucesso");
        return "home";
    }

    public String edita() {
        lembreteDAO.edita(lembrete);
        lembrete = new Lembrete();
        exibeMensagem("Lembrete editado com sucesso");
        return "home";
    }
}
