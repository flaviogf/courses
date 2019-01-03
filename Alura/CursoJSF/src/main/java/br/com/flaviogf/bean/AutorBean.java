package br.com.flaviogf.bean;

import br.com.flaviogf.dao.AutorDAO;
import br.com.flaviogf.modelo.Autor;

import javax.enterprise.context.RequestScoped;
import javax.inject.Inject;
import javax.inject.Named;
import java.util.List;

@Named
@RequestScoped
public class AutorBean {

    @Inject
    private AutorDAO autorDAO;

    @Inject
    private Autor autor;

    public Autor getAutor() {
        return autor;
    }

    public void setAutor(Autor autor) {
        this.autor = autor;
    }

    public List<Autor> getAutores() {
        return autorDAO.lista();
    }

    public String salva() {
        autorDAO.salva(autor);
        return "lista-livro?faces-redirect=true";
    }
}
