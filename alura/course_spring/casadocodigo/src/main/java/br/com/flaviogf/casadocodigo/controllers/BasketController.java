package br.com.flaviogf.casadocodigo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.context.WebApplicationContext;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import br.com.flaviogf.casadocodigo.models.BasketItem;
import br.com.flaviogf.casadocodigo.models.EPriceType;
import br.com.flaviogf.casadocodigo.models.Product;
import br.com.flaviogf.casadocodigo.repositories.ProductRepository;
import br.com.flaviogf.casadocodigo.services.BasketService;

@Controller
@RequestMapping("/basket")
@Scope(value = WebApplicationContext.SCOPE_REQUEST)
public class BasketController {

    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private BasketService basket;

    @RequestMapping(method = RequestMethod.POST)
    public ModelAndView store(Integer productId, EPriceType priceType, RedirectAttributes redirectAttributes) {
        System.out.println(productId);
        System.out.println(priceType);
        Product product = productRepository.get(productId);
        basket.add(new BasketItem(product, priceType));
        redirectAttributes.addFlashAttribute("info", "Product has been added in your basket");
        return new ModelAndView("redirect:/product");
    }
}
