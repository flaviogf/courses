
public class ContaCorrente extends Conta {

	public ContaCorrente(double saldo, String titular) {
		super(saldo, titular);
	}
	
	@Override
	public void saca(double valor) {
		saldo -= 10;
		super.saca(valor);
	}
}
