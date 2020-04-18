package br.com.flaviogf.casadocodigo.validator;

import org.springframework.validation.Errors;
import org.springframework.validation.ValidationUtils;
import org.springframework.validation.Validator;

import br.com.flaviogf.casadocodigo.models.Product;

public class ProductValidator implements Validator {

    @Override
    public boolean supports(Class<?> clazz) {
        return Product.class.isAssignableFrom(clazz);
    }

    @Override
    public void validate(Object target, Errors errors) {
        ValidationUtils.rejectIfEmpty(errors, "name", "Name cannot be empty");
        ValidationUtils.rejectIfEmpty(errors, "summary", "Summary cannot be empty");
        ValidationUtils.rejectIfEmpty(errors, "pages", "Pages cannot be empty");
    }
}
