
public class Autenticador implements Autenticavel {
	private String senha;
	
	public void setSenha(String senha) {
		this.senha = senha;
	}
	
	public boolean autentica(String senha) {
		return this.senha.equalsIgnoreCase(senha);
	}
}
