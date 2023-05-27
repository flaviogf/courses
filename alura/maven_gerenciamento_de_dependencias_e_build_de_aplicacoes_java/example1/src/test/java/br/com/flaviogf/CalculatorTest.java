package br.com.flaviogf;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

public class CalculatorTest {
  @Test
  public void add() {
    Calculator calculator = new Calculator();
    assertEquals(2, calculator.add(1, 1));
  }
}
