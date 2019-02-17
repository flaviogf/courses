package br.com.flaviogf;

import java.sql.SQLException;
import java.sql.Statement;

public class TestaRemocao {

    public static void main(String[] args) {
        BancoDeDados banco = new BancoDeDados();
        banco.criaStatement(TestaRemocao::testaConexao);
    }

    private static void testaConexao(Statement statement) {
        try {
            statement.execute("DELETE FROM PRODUTO WHERE ID > 3");
            int count = statement.getUpdateCount();
            System.out.println(count + " deletados");
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
