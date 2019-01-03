package br.com.flaviogf.resources;

import br.com.flaviogf.dao.CarrinhoDAO;
import br.com.flaviogf.modelo.Carrinho;
import br.com.flaviogf.utils.GsonUtils;

import javax.inject.Inject;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import java.util.List;

@Path("carrinho")
public class CarrinhoResource {

    @Inject
    private CarrinhoDAO dao;

    @Inject
    private GsonUtils gsonUtils;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public String lista() {
        List<Carrinho> lista = dao.lista();
        return gsonUtils.converteParaJson(lista);
    }

    @GET
    @Path("{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public String buscaPor(@PathParam("id") Long id) {
        Carrinho carrinho = dao.buscaPor(id);
        return gsonUtils.converteParaJson(carrinho);
    }

    @POST
    @Produces(MediaType.TEXT_PLAIN)
    public String insere(String json) {
        Carrinho carrinho = gsonUtils.converteParaObjeto(json, Carrinho.class);
        dao.insere(carrinho);
        return "sucesso";
    }
}
