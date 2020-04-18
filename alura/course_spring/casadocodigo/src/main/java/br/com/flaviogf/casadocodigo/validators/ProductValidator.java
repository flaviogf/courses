package br.com.flaviogf.casadocodigo.validators;

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
        ValidationUtils.rejectIfEmpty(errors, "name", "field.required");
        ValidationUtils.rejectIfEmpty(errors, "summary", "field.required");
        ValidationUtils.rejectIfEmpty(errors, "pages", "field.required");
        ValidationUtils.rejectIfEmpty(errors, "releaseDate", "field.required");
    }
}
