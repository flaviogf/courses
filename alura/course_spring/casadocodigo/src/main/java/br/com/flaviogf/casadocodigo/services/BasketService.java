package br.com.flaviogf.casadocodigo.services;

import java.util.LinkedHashMap;
import java.util.Map;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import org.springframework.web.context.WebApplicationContext;

import br.com.flaviogf.casadocodigo.models.BasketItem;

@Component
@Scope(value = WebApplicationContext.SCOPE_SESSION)
public class BasketService {
    private Map<BasketItem, Integer> items = new LinkedHashMap<>();

    public void add(BasketItem basketItem) {
        if (!items.containsKey(basketItem)) {
            items.put(basketItem, 1);
            return;
        }

        items.put(basketItem, items.get(basketItem) + 1);
    }

    public int getQuantity() {
        return items.size();
    }
}
