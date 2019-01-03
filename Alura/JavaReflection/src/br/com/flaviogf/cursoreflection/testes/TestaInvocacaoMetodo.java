package br.com.flaviogf.cursoreflection.testes;

import br.com.flaviogf.cursoreflection.modelos.Usuario;

import static br.com.flaviogf.cursoreflection.utils.InvocaMetodo.executaMetodosGet;
import static br.com.flaviogf.cursoreflection.utils.ValidaTamanhoMinimo.validaCampos;

public class TestaInvocacaoMetodo {

    public static void main(String[] args) {
        try {
            Usuario usuario = new Usuario();
            usuario.setNome("fl");
            usuario.setEmail("flavio@email.com");
            usuario.setSenha("12345678");
            validaCampos(usuario);
            executaMetodosGet(usuario);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
