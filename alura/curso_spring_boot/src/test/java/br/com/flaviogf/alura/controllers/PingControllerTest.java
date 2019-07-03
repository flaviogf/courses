package br.com.flaviogf.alura.controllers;

import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.assertEquals;

public class PingControllerTest {

    @Test
    public void shouldIndexReturnLocalDateTime() {
        var pingController = new PingController();

        var result = pingController.index();

        var expected = LocalDateTime.now();

        assertEquals(expected.getDayOfYear(), result.getDayOfYear());
    }
}
