package br.com.flaviogf;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.math.BigDecimal;
import org.junit.jupiter.api.Test;

public class SalaryAdjustmentTest {
  @Test
  public void applyIncreasesTheSalaryByThreePercent() {
    Employee employee = new SalaryAdjustment(
        new Employee("Frank", new BigDecimal("1000.00"))).apply();

    assertEquals(employee.getSalary(), new BigDecimal("1003.00"));
  }
}
