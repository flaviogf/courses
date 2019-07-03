package br.com.alura.flaviogf.cursospringboot.controllers;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class HelloControllerTests {

    @Test
    public void shouldHelloReturnHello() {
        HelloController controller = new HelloController();

        String result = controller.hello();

        String expected = "Hello";

        assertEquals(expected, result);
    }
}
