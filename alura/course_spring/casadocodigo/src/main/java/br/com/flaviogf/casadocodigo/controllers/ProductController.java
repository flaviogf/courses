package br.com.flaviogf.casadocodigo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import br.com.flaviogf.casadocodigo.models.Product;
import br.com.flaviogf.casadocodigo.repositories.ProductRepository;

@Controller
public class ProductController {
    @Autowired
    private ProductRepository productRepository;

    @RequestMapping("/product/create")
    public String create() {
        return "product/create";
    }

    @RequestMapping("/product/store")
    public String store(Product product) {
        productRepository.add(product);
        System.out.printf("Product %s has been created\n", product);
        return "product/create";
    }
}
