package br.com.flaviogf.exemplos.exemplo004;

class Carro {

    private String modelo;

    public Carro(String modelo) {
        this.modelo = modelo;
    }

    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    @Override
    public String toString() {
        return "Carro: " + modelo;
    }
}

public class Main {

    public static void main(String[] args) {
        int a = 10;
        int b = a;
        a = 20;
        System.out.println(a);
        System.out.println(b);

        Carro teste1 = new Carro("teste1");
        Carro teste2 = new Carro("teste 1");
        Carro mesmaReferencia = teste1;
        teste1.setModelo("teste 1 alterado");
        System.out.print(mesmaReferencia + " ");
        System.out.println(mesmaReferencia == teste1);
        System.out.println();
        System.out.print(teste2 + " ");
        System.out.println(teste1 == teste2);
    }
}
