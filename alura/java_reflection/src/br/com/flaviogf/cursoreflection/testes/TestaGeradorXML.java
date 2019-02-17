package br.com.flaviogf.cursoreflection.testes;

import br.com.flaviogf.cursoreflection.modelos.Usuario;

import static br.com.flaviogf.cursoreflection.utils.GeradorXml.converteParaXML;
import static java.lang.System.out;

public class TestaGeradorXML {

    public static void main(String[] args) {
        Usuario usuario1 = new Usuario();
        usuario1.setEmail("flavio@email.com");
        usuario1.setNome("flavio");
        usuario1.setSenha("123");

        Usuario usuario2 = new Usuario();
        usuario2.setEmail("fernando@email.com");
        usuario2.setNome("fernando");
        usuario2.setSenha("123");

        String xmlUsuario1 = converteParaXML(usuario1);
        String xmlUsuario2 = converteParaXML(usuario2);

        out.println(xmlUsuario1);
        out.println();
        out.println(xmlUsuario2);
    }
}
