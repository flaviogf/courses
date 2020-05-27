package br.com.flaviogf.pizzashop;

import java.util.HashMap;
import java.util.Map;

public class SimpleFactoryPizza {
    private final Map<String, Class<?>> types = new HashMap<>();

    public SimpleFactoryPizza() {
        types.put("cheese", CheesePizza.class);
        types.put("clam", ClamPizza.class);
        types.put("pepperoni", PepperoniPizza.class);
        types.put("veggie", VeggiePizza.class);
    }

    public Pizza create(String type) {
        if (!types.containsKey(type)) {
            return null;
        }

        try {
            return (Pizza) types.get(type).getConstructor().newInstance();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
