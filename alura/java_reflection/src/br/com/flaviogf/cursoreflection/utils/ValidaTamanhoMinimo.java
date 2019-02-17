package br.com.flaviogf.cursoreflection.utils;

import br.com.flaviogf.cursoreflection.modelos.AnotacaoValidaTamanhoMinimo;

import java.lang.reflect.Field;

import static java.lang.String.format;

public class ValidaTamanhoMinimo {

    public static void validaCampos(Object o) throws IllegalAccessException {
        Class<?> clazz = o.getClass();
        for (Field field : clazz.getDeclaredFields()) {
            field.setAccessible(true);
            boolean naoTem = !field.isAnnotationPresent(AnotacaoValidaTamanhoMinimo.class);
            if (naoTem) continue;
            AnotacaoValidaTamanhoMinimo anotacao = field.getAnnotation(AnotacaoValidaTamanhoMinimo.class);
            int tamanhoMinimo = anotacao.value();
            Object valor = field.get(o);
            boolean valido = !(valor.toString().length() < tamanhoMinimo);
            if (valido) continue;
            throw new IllegalArgumentException(format("Campo '%s' deve conter no minimo '%s' caracteres", field.getName(), tamanhoMinimo));
        }
    }
}
