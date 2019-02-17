
public class Administrador extends FuncionarioAutenticavel {

	public Administrador(String nome, String cpf, double salario, String senha) {
		super(nome, cpf, salario, senha);
	}

	@Override
	public double getBonificacao() {
		return 50;
	}
}
