
public class TestaConta {
	public static void main(String[] args) {
		Conta conta = new ContaCorrente(500, "Flavio");
		conta.saca(250);
		System.out.println(conta.getSaldo());
	}
}
