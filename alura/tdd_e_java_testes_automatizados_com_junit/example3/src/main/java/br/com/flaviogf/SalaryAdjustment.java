package br.com.flaviogf;

import java.math.BigDecimal;

public class SalaryAdjustment {
  private final Employee employee;
  private final Performance performance;

  public SalaryAdjustment(Employee employee, Performance performance) {
    this.employee = employee;
    this.performance = performance;
  }

  public Employee apply() {
    return new Employee(employee.getName(), performance.apply(employee.getSalary()));
  }
}
