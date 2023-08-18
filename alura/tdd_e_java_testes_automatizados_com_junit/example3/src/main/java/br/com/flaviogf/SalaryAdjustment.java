package br.com.flaviogf;

import java.math.BigDecimal;

public class SalaryAdjustment {
  private final Employee employee;

  public SalaryAdjustment(Employee employee) {
    this.employee = employee;
  }

  public Employee apply() {
    return new Employee(employee.getName(), new BigDecimal("1003.00"));
  }
}
