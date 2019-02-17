
public class TestaFuncionarioAutenticavel {
	public static void main(String[] args) {
		SistemaInterno sistema = new SistemaInterno();
		Administrador adiminstrador = new Administrador("Flavio", "123.123.123-12", 1000, "123");
		Gerente gerente = new Gerente("Fernando", "123.123.123-12", 1000, "123");
		Cliente cliente = new Cliente("Teste", "123");
		System.out.println(sistema.autentica(adiminstrador));
		System.out.println(sistema.autentica(gerente));
		System.out.println(sistema.autentica(cliente));
	}
}
