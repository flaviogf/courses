package br.com.flaviogf.cursoreflection.utils;

import java.io.FileInputStream;
import java.lang.reflect.Constructor;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;
import java.util.stream.Collectors;

import static java.lang.String.format;

public class Mapeador {

    private Map<Class<?>, Class<?>> mapa = new HashMap<>();

    public void carrega(String arquivo) throws Exception {
        FileInputStream stream = new FileInputStream(arquivo);
        Properties properties = new Properties();
        properties.load(stream);
        properties.forEach((key, value) -> {
            try {
                Class<?> interf = Class.forName(key.toString());
                Class<?> imple = Class.forName(value.toString());
                if (!interf.isInterface()) {
                    throw new IllegalArgumentException(format("%s não é uma interface", interf.getName()));
                }
                if (!interf.isAssignableFrom(imple)) {
                    throw new IllegalArgumentException(format("%s não implementa %s", imple.getName(), interf.getName()));
                }
                mapa.put(interf, imple);
            } catch (ClassNotFoundException ignored) {
                throw new RuntimeException();
            }
        });
    }

    public <E> E getImplementacao(Class<E> clazz) throws Exception {
        return (E) mapa.get(clazz).newInstance();
    }

    public <E> E getImplementacao(Class<E> clazz, Object... args) throws Exception {
        Class<?> imple = mapa.get(clazz);
        Class[] parametros = Arrays.stream(args)
                .map(Object::getClass)
                .collect(Collectors.toList())
                .toArray(new Class[args.length]);
        Constructor<?> construtor = imple.getDeclaredConstructor(parametros);
        return (E) construtor.newInstance(args);
    }
}
