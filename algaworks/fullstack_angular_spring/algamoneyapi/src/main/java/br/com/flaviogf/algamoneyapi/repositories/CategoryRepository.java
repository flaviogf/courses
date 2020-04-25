package br.com.flaviogf.algamoneyapi.repositories;

import br.com.flaviogf.algamoneyapi.models.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, Long> {
}
