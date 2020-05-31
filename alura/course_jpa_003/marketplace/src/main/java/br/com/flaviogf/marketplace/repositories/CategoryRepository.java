package br.com.flaviogf.marketplace.repositories;

import br.com.flaviogf.marketplace.models.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, Long> {
}
