package br.com.flaviogf.dao;

import br.com.flaviogf.model.Produto;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ProdutoDAO {

    private final Connection connection;

    public ProdutoDAO(Connection connection) {
        this.connection = connection;
    }

    public List<Produto> lista() throws SQLException {
        try (PreparedStatement statement = connection.prepareStatement("SELECT * FROM PRODUTO")) {
            List<Produto> produtos = new ArrayList<>();
            statement.execute();
            ResultSet resultSet = statement.getResultSet();
            while (resultSet.next()) {
                int id = resultSet.getInt("ID");
                String nome = resultSet.getString("NOME");
                String descricao = resultSet.getString("DESCRICAO");
                produtos.add(new Produto(id, nome, descricao));
            }
            return produtos;
        }
    }
}
