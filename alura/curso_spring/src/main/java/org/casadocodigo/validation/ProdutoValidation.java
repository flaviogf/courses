package org.casadocodigo.validation;

import org.casadocodigo.models.Produto;
import org.springframework.stereotype.Component;
import org.springframework.validation.Errors;
import org.springframework.validation.ValidationUtils;
import org.springframework.validation.Validator;

@Component
public class ProdutoValidation implements Validator {

    @Override
    public boolean supports(Class<?> clazz) {
        return Produto.class.isAssignableFrom(clazz);
    }

    @Override
    public void validate(Object targeto, Errors errors) {
        ValidationUtils.rejectIfEmptyOrWhitespace(errors, "titulo", "erro_titulo");
        ValidationUtils.rejectIfEmptyOrWhitespace(errors, "descricao", "erro_descricao");

        Produto produto = (Produto) targeto;
        if (produto.getValor() <= 0) {
            errors.rejectValue("valor", "erro_valor");
        }
    }
}
