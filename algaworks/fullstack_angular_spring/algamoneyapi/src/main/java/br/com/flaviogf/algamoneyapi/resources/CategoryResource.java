package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.models.Category;
import br.com.flaviogf.algamoneyapi.repositories.CategoryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import javax.validation.Valid;
import java.net.URI;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/categories")
public class CategoryResource {
    private final CategoryRepository categoryRepository;

    @Autowired
    public CategoryResource(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @GetMapping
    @PreAuthorize("hasRole('READ_CATEGORY')")
    public ResponseEntity<List<Category>> index() {
        List<Category> categories = categoryRepository.findAll();

        return ResponseEntity.ok(categories);
    }

    @PostMapping
    @PreAuthorize("hasRole('CREATE_CATEGORY')")
    public ResponseEntity<Category> store(@Valid @RequestBody Category category) {
        Category created = categoryRepository.save(category);

        URI uri = ServletUriComponentsBuilder.fromCurrentRequest().path("/{id}").buildAndExpand(created.getId()).toUri();

        return ResponseEntity.created(uri).body(created);
    }

    @GetMapping("/{id}")
    @PreAuthorize("hasRole('READ_CATEGORY')")
    public ResponseEntity<Category> show(@PathVariable Long id) {
        Optional<Category> category = categoryRepository.findById(id);

        return category.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
