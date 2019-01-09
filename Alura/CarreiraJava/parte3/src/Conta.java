
public abstract class Conta {
	protected double saldo;
	protected String titular;
	
	public Conta(double saldo, String titular) {
		super();
		this.saldo = saldo;
		this.titular = titular;
	}

	public double getSaldo() {
		return saldo;
	}

	public String getTitular() {
		return titular;
	}
	
	public void saca(double valor) {
		saldo -= valor;
	}
}
