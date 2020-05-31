package br.com.flaviogf.marketplace.repositories;

import br.com.flaviogf.marketplace.models.Product;

import java.util.List;

public interface ProductQueryByNameCategoryAndStore {
    List<Product> findAll(String name, Long categoryId, Long storeId);
}
