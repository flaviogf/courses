
public class Conexao implements AutoCloseable {
	
	public Conexao() {
		System.out.println("iniciando");
		throw new RuntimeException("erro");
	}

	@Override
	public void close() {
		System.out.println("fechando");
	}
}
