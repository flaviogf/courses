package br.com.flaviogf;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class TestaConexao {

    public static void main(String[] args) {
        BancoDeDados banco = new BancoDeDados();
        banco.criaStatement(TestaConexao::testaConexao);
    }

    private static void testaConexao(Statement statement) {
        try {
            statement.execute("CREATE TABLE IF NOT EXISTS PRODUTO (ID INTEGER PRIMARY KEY AUTOINCREMENT, NOME TEXT, DESCRICAO TEXT)");
            statement.execute("SELECT * FROM PRODUTO");
            try (ResultSet result = statement.getResultSet()) {
                while (result.next()) {
                    System.out.println(result.getString("NOME") + " " + result.getString("DESCRICAO"));
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
