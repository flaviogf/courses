package br.com.flaviogf.bean;

import br.com.flaviogf.dao.LivroDAO;
import br.com.flaviogf.modelo.Autor;
import br.com.flaviogf.modelo.Livro;

import javax.annotation.PostConstruct;
import javax.enterprise.context.RequestScoped;
import javax.inject.Inject;
import javax.inject.Named;
import java.util.List;

@Named
@RequestScoped
public class LivroBean {

    @Inject
    private LivroDAO livroDao;

    @Inject
    private Livro livro;

    private Integer idAutor;

    private List<Livro> livros;

    @PostConstruct
    public void inicializa() {
        livros = livroDao.lista();
    }

    public Livro getLivro() {
        return livro;
    }

    public void setLivro(Livro livro) {
        this.livro = livro;
    }

    public Integer getIdAutor() {
        return idAutor;
    }

    public void setIdAutor(Integer idAutor) {
        this.idAutor = idAutor;
    }

    public List<Livro> getLivros() {
        return livros;
    }

    public String salva() {
        livroDao.salva(livro);
        return "lista-livro?faces-redirect=true";
    }

    public void adiciona() {
        Autor autor = new Autor();
        autor.setId(idAutor);
        livro.adiciona(autor);
    }
}
