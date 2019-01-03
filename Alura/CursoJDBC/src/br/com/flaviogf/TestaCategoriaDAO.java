package br.com.flaviogf;

import br.com.flaviogf.dao.CategoriaDAO;
import br.com.flaviogf.model.Categoria;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;

public class TestaCategoriaDAO {

    public static void main(String[] args) {
        BancoDeDados bancoDeDados = new BancoDeDados();
        bancoDeDados.criaConexao(TestaCategoriaDAO::testaCategoriaDAO);
    }

    private static void testaCategoriaDAO(Connection connection) {
        try {
            CategoriaDAO categoriaDAO = new CategoriaDAO(connection);
            List<Categoria> categorias = categoriaDAO.lista();
            categorias.forEach(System.out::println);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
