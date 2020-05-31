package br.com.flaviogf.marketplace.repositories;

import br.com.flaviogf.marketplace.models.Product;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProductRepository extends JpaRepository<Product, Long>, ProductQueryByNameCategoryAndStore {
}
