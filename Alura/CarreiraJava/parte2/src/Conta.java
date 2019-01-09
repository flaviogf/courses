
public class Conta {
	private double saldo;
	private String agencia;
	private String numero;
	private Cliente cliente;
	
	public Conta(String agencia, String numero, Cliente cliente) {
		super();
		this.agencia = agencia;
		this.numero = numero;
		this.cliente = cliente;
	}
	
	public double getSaldo() {
		return saldo;
	}
	
	public String getAgencia() {
		return agencia;
	}
	
	public String getNumero() {
		return numero;
	}
	
	public Cliente getCliente() {
		return cliente;
	}
}
