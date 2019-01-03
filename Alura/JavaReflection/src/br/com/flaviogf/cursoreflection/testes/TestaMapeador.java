package br.com.flaviogf.cursoreflection.testes;

import br.com.flaviogf.cursoreflection.modelos.InterfaceExemplo;
import br.com.flaviogf.cursoreflection.utils.Mapeador;

import java.util.List;

import static java.lang.System.out;

public class TestaMapeador {

    public static void main(String[] args) throws Exception {
        Mapeador mapeador = new Mapeador();
        mapeador.carrega("configuracao.properties");
        List implementacao = mapeador.getImplementacao(List.class);
        out.println(implementacao.getClass());
        InterfaceExemplo interfaceExemplo = mapeador.getImplementacao(InterfaceExemplo.class, "teste");
        out.println(interfaceExemplo.getClass());
    }
}
