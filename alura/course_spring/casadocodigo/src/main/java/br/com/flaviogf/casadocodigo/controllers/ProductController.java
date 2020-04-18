package br.com.flaviogf.casadocodigo.controllers;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import br.com.flaviogf.casadocodigo.infrastructure.FileSaver;
import br.com.flaviogf.casadocodigo.models.EPriceType;
import br.com.flaviogf.casadocodigo.models.Product;
import br.com.flaviogf.casadocodigo.repositories.ProductRepository;
import br.com.flaviogf.casadocodigo.validators.ProductValidator;

@Controller
@RequestMapping("/product")
public class ProductController {
    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private FileSaver fileSaver;

    @InitBinder
    private void initBinder(WebDataBinder binder) {
        binder.addValidators(new ProductValidator());
    }

    @RequestMapping(method = RequestMethod.GET)
    public ModelAndView index() {
        ModelAndView modelAndView = new ModelAndView("product/index");
        List<Product> products = productRepository.all();
        modelAndView.addObject("products", products);
        return modelAndView;
    }

    @RequestMapping(value = "create", method = RequestMethod.GET)
    public ModelAndView create(Product product) {
        ModelAndView modelAndView = new ModelAndView("product/create");
        modelAndView.addObject("priceTypes", EPriceType.values());
        modelAndView.addObject("product", product);
        return modelAndView;
    }

    @RequestMapping(value = "store", method = RequestMethod.POST)
    public ModelAndView store(MultipartFile file, @Valid Product product, BindingResult bindingResult,
            RedirectAttributes redirectAttributes) {
        if (bindingResult.hasErrors()) {
            System.out.println(bindingResult.getAllErrors());
            return create(product);
        }

        product.setCover(fileSaver.write("images", file));

        productRepository.add(product);

        redirectAttributes.addFlashAttribute("info", "Product has been created.");

        return new ModelAndView("redirect:/product");
    }
}
