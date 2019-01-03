package br.com.flaviogf.cursoreflection.testes;

import br.com.flaviogf.cursoreflection.modelos.Usuario;

import java.lang.reflect.Field;
import java.util.List;
import java.util.Objects;
import java.util.function.Predicate;
import java.util.stream.Stream;

import static java.lang.System.out;
import static java.util.stream.Collectors.toList;

public class TestaBuscaDeCampos {

    public static void main(String[] args) {
        Usuario usuario = new Usuario();
        usuario.setEmail("flavio@email.com");
        out.println("Campos não nulos");
        campos(usuario, Objects::nonNull).forEach(out::println);
        out.println("Campos nulos");
        campos(usuario, Objects::isNull).forEach(out::println);
    }

    private static List<String> campos(Object o, Predicate<Object> filtro) {
        Field[] campos = o.getClass().getDeclaredFields();
        return Stream.of(campos)
                .filter(it -> {
                    it.setAccessible(true);
                    try {
                        return filtro.test(it.get(o));
                    } catch (IllegalAccessException e) {
                        return false;
                    }
                })
                .map(Field::getName)
                .collect(toList());
    }
}
