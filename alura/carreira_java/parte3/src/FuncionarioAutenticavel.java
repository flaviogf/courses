
public abstract class FuncionarioAutenticavel extends Funcionario implements Autenticavel {
	private Autenticavel autenticador = new Autenticador();
	
	public FuncionarioAutenticavel(String nome, String cpf, double salario, String senha) {
		super(nome, cpf, salario);
		setSenha(senha);
	}
	
	@Override
	public void setSenha(String senha) {
		autenticador.setSenha(senha);
	}
	
	public boolean autentica(String senha) {
		return autenticador.autentica(senha);
	}
}
