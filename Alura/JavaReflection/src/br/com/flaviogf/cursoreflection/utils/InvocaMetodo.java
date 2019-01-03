package br.com.flaviogf.cursoreflection.utils;

import java.util.Arrays;

public class InvocaMetodo {

    public static void executaMetodosGet(Object o) {
        Class<?> clazz = o.getClass();
        Arrays.stream(clazz.getMethods()).forEach(metodo -> {
            try {
                boolean ehMetodoGet = metodo.getName().startsWith("get") && !metodo.getName().endsWith("Class");
                if (!ehMetodoGet) return;
                System.out.println(metodo.invoke(o));
            } catch (Exception ignored) {

            }
        });
    }
}
