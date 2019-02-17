
public class Fluxo {
	public static void main(String[] args) {
		System.out.println("Inicio main");
		try {
			// metodo1();			
			// metodo3();
			metodo4();
		} catch (ArithmeticException | NullPointerException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}

		System.out.println("Fim main");
	}

	private static void metodo1() {
		System.out.println("Inicio metodo1");
		metodo2();
		System.out.println("Fim metodo1");
	}

	private static void metodo2() {
		System.out.println("Inicio metodo2");
		throw new ArithmeticException("erro");
	}
	
	private static void metodo3() {
		throw new UncheckedException("erro");
	}
	
	private static void metodo4() throws CheckedException {
		throw new CheckedException("erro");
	}
}
