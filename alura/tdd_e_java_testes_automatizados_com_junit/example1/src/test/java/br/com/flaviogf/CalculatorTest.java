package br.com.flaviogf;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

public class CalculatorTest {
  @Test
  public void addTwoNumbers() {
    Calculator calculator = new Calculator();
    assertEquals(10, calculator.add(3, 7));
  }
}
