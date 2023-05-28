package br.com.flaviogf;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.math.BigDecimal;

import org.junit.jupiter.api.Test;

public class BonusTest {
  @Test
  public void valueReturnsATenPercentBonus() {
    Employee employee = new Employee("Peter", new BigDecimal("2500.00"));
    BigDecimal value = new Bonus(employee).getValue();
    assertEquals(new BigDecimal("250.00"), value);
  }

  @Test
  public void valueReturnsAZeroBonusWhenSalaryIsGreaterThanTenThousand() {
    Employee employee = new Employee("Bruce", new BigDecimal("10001.00"));
    BigDecimal value = new Bonus(employee).getValue();
    assertEquals(Bonus.ZERO, value);
  }
}
