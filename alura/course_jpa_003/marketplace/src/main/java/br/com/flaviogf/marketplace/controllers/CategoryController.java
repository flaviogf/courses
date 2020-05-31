package br.com.flaviogf.marketplace.controllers;

import br.com.flaviogf.marketplace.models.Category;
import br.com.flaviogf.marketplace.repositories.CategoryRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/category")
public class CategoryController {
    private final CategoryRepository categoryRepository;

    public CategoryController(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @GetMapping
    public ResponseEntity<List<Category>> index() {
        List<Category> categories = categoryRepository.findAll();

        return ResponseEntity.ok(categories);
    }
}
