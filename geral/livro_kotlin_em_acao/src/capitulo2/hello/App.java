package capitulo2.hello;

public class App {

    public static void main(String[] args) {
        Funcionario funcionario = new Funcionario("flavio", true);
        System.out.println(funcionario.getNome());
        funcionario.setAtivo(false);
        System.out.println(funcionario.isAtivo());
    }
}
