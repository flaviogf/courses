package br.com.flaviogf.alura.errorhandler;

import org.junit.Test;
import org.springframework.context.MessageSource;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.BindingResult;
import org.springframework.validation.FieldError;
import org.springframework.web.bind.MethodArgumentNotValidException;

import java.util.Collections;
import java.util.List;

import static org.junit.Assert.assertEquals;
import static org.mockito.Matchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class ValidationErrorHandlerTest {

    @Test
    public void shouldHandleReturnStatusCodeBadRequest() {
        String message = "error";
        FieldError fieldError = new FieldError("Course", "name", "not is empty");

        MessageSource messageSource = mock(MessageSource.class);
        when(messageSource.getMessage(any(), any())).thenReturn(message);

        BindingResult bindingResult = mock(BindingResult.class);
        when(bindingResult.getFieldErrors()).thenReturn(Collections.singletonList(fieldError));

        MethodArgumentNotValidException ex = mock(MethodArgumentNotValidException.class);
        when(ex.getBindingResult()).thenReturn(bindingResult);

        ValidationErrorHandler handler = new ValidationErrorHandler(messageSource);

        ResponseEntity<List<String>> response = handler.handle(ex);

        assertEquals(HttpStatus.BAD_REQUEST, response.getStatusCode());
    }

    @Test
    public void shouldHandleReturnErrorsList() {
        String message = "error";
        FieldError fieldError = new FieldError("Course", "name", "not is empty");

        MessageSource messageSource = mock(MessageSource.class);
        when(messageSource.getMessage(any(), any())).thenReturn(message);

        BindingResult bindingResult = mock(BindingResult.class);
        when(bindingResult.getFieldErrors()).thenReturn(Collections.singletonList(fieldError));

        MethodArgumentNotValidException ex = mock(MethodArgumentNotValidException.class);
        when(ex.getBindingResult()).thenReturn(bindingResult);

        ValidationErrorHandler handler = new ValidationErrorHandler(messageSource);

        ResponseEntity<List<String>> response = handler.handle(ex);

        String result = response.getBody().get(0);

        assertEquals(message, result);
    }
}
