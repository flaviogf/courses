
public class TestaConexao {
	public static void main(String[] args) {
		try (Conexao con = new Conexao()) {
			System.out.println(con.toString());
		} catch (RuntimeException ex) {
			System.out.println(ex.getMessage());
		}
	}
}