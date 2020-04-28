package br.com.flaviogf.algamoneyapi.infrastructure;

import br.com.flaviogf.algamoneyapi.exceptions.AlgaMoneyException;
import org.springframework.context.MessageSource;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.http.converter.HttpMessageNotReadableException;
import org.springframework.validation.FieldError;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.util.Collections;
import java.util.List;
import java.util.Locale;

import static java.util.stream.Collectors.toList;

@ControllerAdvice
public class CustomExceptionHandler extends ResponseEntityExceptionHandler {
    private final MessageSource messageSource;

    public CustomExceptionHandler(MessageSource messageSource) {
        this.messageSource = messageSource;
    }

    @ExceptionHandler(DataIntegrityViolationException.class)
    public ResponseEntity<Object> handleDataIntegrityViolationException(DataIntegrityViolationException ex, WebRequest request) {
        String message = messageSource.getMessage("message.error.default", null, Locale.getDefault());

        List<Error> errors = Collections.singletonList(new Error(message, ex.getMessage()));

        return handleExceptionInternal(ex, errors, new HttpHeaders(), HttpStatus.BAD_REQUEST, request);
    }

    @ExceptionHandler(AlgaMoneyException.class)
    public ResponseEntity<Object> handleAlgaMoneyException(AlgaMoneyException ex, WebRequest request) {
        String message = messageSource.getMessage(ex.getMessageSource(), null, Locale.getDefault());

        List<Error> errors = Collections.singletonList(new Error(message, ex.getMessage()));

        return handleExceptionInternal(ex, errors, new HttpHeaders(), HttpStatus.BAD_REQUEST, request);
    }

    @Override
    protected ResponseEntity<Object> handleHttpMessageNotReadable(HttpMessageNotReadableException ex, HttpHeaders headers, HttpStatus status, WebRequest request) {
        String message = messageSource.getMessage("message.error.default", null, Locale.getDefault());

        List<Error> errors = Collections.singletonList(new Error(message, ex.getCause().getMessage()));

        return handleExceptionInternal(ex, errors, headers, HttpStatus.BAD_REQUEST, request);
    }

    @Override
    protected ResponseEntity<Object> handleMethodArgumentNotValid(MethodArgumentNotValidException ex, HttpHeaders headers, HttpStatus status, WebRequest request) {
        List<Error> errors = ex.getBindingResult().getFieldErrors().stream().map(this::toError).collect(toList());

        return handleExceptionInternal(ex, errors, headers, HttpStatus.BAD_REQUEST, request);
    }

    private Error toError(FieldError fieldError) {
        String friendly = messageSource.getMessage(fieldError, Locale.getDefault());
        String detail = fieldError.toString();
        return new Error(friendly, detail);
    }
}
