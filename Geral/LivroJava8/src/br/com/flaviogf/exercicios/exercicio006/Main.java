package br.com.flaviogf.exercicios.exercicio006;

import br.com.flaviogf.exercicios.exercicio006.model.Pessoa;

public class Main {

    public static void main(String[] args) {
        Pessoa pessoa = new Pessoa("flavio", "fernandes");
        System.out.println(pessoa.getNome());
        System.out.println(pessoa.getSobrenome());
    }
}
