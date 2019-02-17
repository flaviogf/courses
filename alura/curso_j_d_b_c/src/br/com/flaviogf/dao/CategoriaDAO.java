package br.com.flaviogf.dao;

import br.com.flaviogf.model.Categoria;
import br.com.flaviogf.model.Produto;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class CategoriaDAO {

    private final Connection connection;

    public CategoriaDAO(Connection connection) {
        this.connection = connection;
    }

    public List<Categoria> lista() throws SQLException {
        String sql = "SELECT C.ID AS categoriaID, C.NOME AS categoriaNome, P.ID AS produtoID, P.NOME AS produtoNome, P.DESCRICAO AS produtoDescricao FROM CATEGORIA C JOIN PRODUTO P ON P.ID_CATEGORIA = C.ID ORDER BY C.ID";
        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            List<Categoria> categorias = new ArrayList<>();
            Categoria ultima = null;
            statement.execute();
            ResultSet resultSet = statement.getResultSet();
            while (resultSet.next()) {
                int idCategoria = resultSet.getInt("categoriaId");
                String categoriaNome = resultSet.getString("categoriaNome");
                if (ultima == null || !ultima.getNome().equals(categoriaNome)) {
                    ultima = new Categoria(idCategoria, categoriaNome);
                    categorias.add(ultima);
                }
                int produtoId = resultSet.getInt("produtoId");
                String produtoNome = resultSet.getString("produtoNome");
                String produtoDescricao = resultSet.getString("produtoDescricao");
                ultima.adiciona(new Produto(produtoId, produtoNome, produtoDescricao));
            }
            return categorias;
        }
    }
}
