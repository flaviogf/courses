
public class Cliente implements Autenticavel {
	private String nome;
	private Autenticavel autenticador = new Autenticador();
	
	public Cliente(String nome, String senha) {
		this.nome = nome;
		setSenha(senha);
	}

	@Override
	public void setSenha(String senha) {
		autenticador.setSenha(senha);
	}

	@Override
	public boolean autentica(String senha) {
		return autenticador.autentica(senha);
	}
	
	public String getNome() {
		return nome;
	}
}
