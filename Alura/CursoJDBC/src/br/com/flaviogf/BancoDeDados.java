package br.com.flaviogf;

import org.sqlite.SQLiteDataSource;

import javax.sql.DataSource;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.function.Consumer;

public class BancoDeDados {

    private DataSource dataSource;

    public BancoDeDados() {
        SQLiteDataSource dataSource = new SQLiteDataSource();
        dataSource.setUrl("jdbc:sqlite:banco.db");
        this.dataSource = dataSource;
    }

    private Connection getConnection() throws SQLException {
        return dataSource.getConnection();
    }

    public void criaStatement(Consumer<Statement> consumer) {
        try (Connection conexao = getConnection()) {
            try (Statement statement = conexao.createStatement()) {
                consumer.accept(statement);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void criaConexao(Consumer<Connection> consumer) {
        try (Connection connection = getConnection()) {
            consumer.accept(connection);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
