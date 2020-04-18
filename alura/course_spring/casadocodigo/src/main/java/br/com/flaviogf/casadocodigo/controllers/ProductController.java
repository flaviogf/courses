package br.com.flaviogf.casadocodigo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import br.com.flaviogf.casadocodigo.models.EPriceType;
import br.com.flaviogf.casadocodigo.models.Product;
import br.com.flaviogf.casadocodigo.repositories.ProductRepository;

@Controller
public class ProductController {
    @Autowired
    private ProductRepository productRepository;

    @RequestMapping("/product/create")
    public ModelAndView create() {
        ModelAndView modelAndView = new ModelAndView("product/create");
        modelAndView.addObject("priceTypes", EPriceType.values());
        return modelAndView;
    }

    @RequestMapping("/product/store")
    public String store(Product product) {
        productRepository.add(product);
        System.out.printf("Product %s has been created\n", product);
        return "product/create";
    }
}
