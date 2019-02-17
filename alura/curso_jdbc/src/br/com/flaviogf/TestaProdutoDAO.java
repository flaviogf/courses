package br.com.flaviogf;

import br.com.flaviogf.dao.ProdutoDAO;
import br.com.flaviogf.model.Produto;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;

public class TestaProdutoDAO {

    public static void main(String[] args) {
        BancoDeDados bancoDeDados = new BancoDeDados();
        bancoDeDados.criaConexao(TestaProdutoDAO::testaProdutoDao);
    }

    private static void testaProdutoDao(Connection connection) {
        try {
            ProdutoDAO produtoDAO = new ProdutoDAO(connection);
            List<Produto> produtos = produtoDAO.lista();
            produtos.forEach(System.out::println);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
