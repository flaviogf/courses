package br.com.flaviogf.cursoreflection.utils;

import java.lang.reflect.Field;
import java.util.Arrays;

import static java.lang.String.format;

public class GeradorXml {

    public static String converteParaXML(Object o) {
        Class<?> clazz = o.getClass();
        String inicio = format("<%1$s>\n", clazz.getSimpleName());
        String corpo = Arrays.stream(clazz.getDeclaredFields()).map(it -> mapeaItemParaXML(o, it)).reduce((acc, it) -> acc + it).orElse("null");
        String fim = format("</%1$s>", clazz.getSimpleName());
        return inicio + corpo + fim;
    }

    private static String mapeaItemParaXML(Object o, Field it) {
        try {
            it.setAccessible(true);
            return format("<%1$s>%2$s</%1$s>\n", it.getName(), it.get(o));
        } catch (IllegalAccessException e) {
            return format("<%1$s>null</%1$s>\n", it.getName());
        }
    }
}
