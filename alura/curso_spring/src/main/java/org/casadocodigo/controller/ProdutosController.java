package org.casadocodigo.controller;

import org.casadocodigo.dao.ProdutoDao;
import org.casadocodigo.models.Produto;
import org.casadocodigo.models.TipoPreco;
import org.casadocodigo.utils.ArquivoUtil;
import org.casadocodigo.validation.ProdutoValidation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import java.util.List;

import static org.springframework.web.bind.annotation.RequestMethod.GET;
import static org.springframework.web.bind.annotation.RequestMethod.POST;

@Controller
@RequestMapping("produtos")
public class ProdutosController {

    @Autowired
    private ProdutoDao dao;

    @Autowired
    private ProdutoValidation validation;

    @Autowired
    private ArquivoUtil arquivoUtil;

    @InitBinder
    private void vincula(WebDataBinder binder) {
        binder.addValidators(validation);
    }

    @RequestMapping(method = GET)
    public ModelAndView lista() {
        List<Produto> produtos = dao.lista();
        ModelAndView modelAndView = new ModelAndView("produtos/index");
        modelAndView.addObject("produtos", produtos);
        return modelAndView;
    }

    @RequestMapping(method = POST)
    public ModelAndView salva(@Validated Produto produto, BindingResult result, MultipartFile arquivoSumario, RedirectAttributes redirectAttributes) {
        if (result.hasErrors()) return formulario(produto);
        produto.setSumario(arquivoUtil.salva(arquivoSumario));
        dao.grava(produto);
        redirectAttributes.addFlashAttribute("sucesso", "Produto cadastrado com sucesso");
        return new ModelAndView("redirect:/produtos");
    }

    @RequestMapping("/formulario")
    public ModelAndView formulario(Produto produto) {
        ModelAndView modelAndView = new ModelAndView("produtos/formulario");
        modelAndView.addObject("tipos", TipoPreco.values());
        return modelAndView;
    }
}
