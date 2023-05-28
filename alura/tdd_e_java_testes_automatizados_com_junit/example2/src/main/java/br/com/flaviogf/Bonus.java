package br.com.flaviogf;

import java.math.BigDecimal;
import java.math.RoundingMode;

public class Bonus {
  public static final BigDecimal ZERO = new BigDecimal("0.00");

  private final Employee employee;

  public Bonus(Employee employee) {
    this.employee = employee;
  }

  public BigDecimal getValue() {
    if (employee.getSalary().compareTo(new BigDecimal("10000.00")) >= 1) {
      return ZERO;
    }

    return employee.getSalary().multiply(new BigDecimal("0.1")).setScale(2, RoundingMode.HALF_UP);
  }
}
