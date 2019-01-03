package br.com.flaviogf.utils;

import br.com.flaviogf.models.Produto;
import br.com.flaviogf.property.ItensProperty;

public class ProdutoUtils {

    public static ItensProperty mapeaParaItensProperty(Produto produto) {
        return new ItensProperty(produto.getProduto(), produto.getPreco());
    }
}
