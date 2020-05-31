package br.com.flaviogf.marketplace.controllers;

import br.com.flaviogf.marketplace.models.Product;
import br.com.flaviogf.marketplace.repositories.ProductRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/product")
public class ProductController {
    private final ProductRepository productRepository;

    public ProductController(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @GetMapping
    public ResponseEntity<List<Product>> index(@RequestParam(value = "name", required = false) String name, @RequestParam(value = "categoryId", required = false) Long categoryId, @RequestParam(value = "storeId", required = false) Long storeId) {
        List<Product> products = productRepository.findAll(name, categoryId, storeId);

        return ResponseEntity.ok(products);
    }
}
