package br.com.flaviogf.alura.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.time.LocalDateTime;

@RestController
@RequestMapping("")
public class PingController {

    @GetMapping
    public LocalDateTime index() {
        return LocalDateTime.now();
    }
}
