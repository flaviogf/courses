package br.com.flaviogf;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

public class TestaInsercao {


    public static void main(String[] args) {
        BancoDeDados banco = new BancoDeDados();
        banco.criaStatement(TestaInsercao::testaInsercao);
        banco.criaConexao(TestaInsercao::testaInsercao);
        banco.criaConexao(connection -> {
            try {
                testaInsercaoComTransacao(connection);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        });
    }

    private static void testaInsercao(Statement statement) {
        try {
            boolean execute = statement.execute("INSERT INTO PRODUTO (NOME, DESCRICAO) VALUES ('PS3', 'DESCRICAO PS3')");
            System.out.println(execute);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    private static void testaInsercao(Connection connection) {
        try {
            PreparedStatement prepareStatement = connection.prepareStatement("INSERT INTO PRODUTO (NOME, DESCRICAO) VALUES (?, ?)");
            prepareStatement.setString(1, "XBOX 360");
            prepareStatement.setString(2, "DESCRICAO XBOX 360");
            boolean execute = prepareStatement.execute();
            System.out.println(execute);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    private static void testaInsercaoComTransacao(Connection connection) throws SQLException {
        try {
            connection.setAutoCommit(false);
            adicionaProduto(connection, "TESTE", "DESCRICAO TESTE");
            adicionaProduto(connection, "TESTE 2", "DESCRICAO TESTE 2");
            connection.commit();
        } catch (Exception e) {
            connection.rollback();
            e.printStackTrace();
            System.out.println("Executando rollback");
        }
    }

    private static void adicionaProduto(Connection connection, String nome, String descricao) throws IllegalAccessException, SQLException {
        if (nome.equals("TESTE 2")) throw new IllegalAccessException();
        try (PreparedStatement prepareStatement = connection.prepareStatement("INSERT INTO PRODUTO (NOME, DESCRICAO) VALUES (?, ?)")) {
            prepareStatement.setString(1, nome);
            prepareStatement.setString(2, descricao);
        }
    }
}
