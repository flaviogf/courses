
public class TestaConta {
	public static void main(String[] args) {
		Cliente cliente = new Cliente("flavio", "123.123.123-12");
		Conta conta = new Conta("123", "456", cliente);
		System.out.println(conta.getCliente().getNome());
	}
}
