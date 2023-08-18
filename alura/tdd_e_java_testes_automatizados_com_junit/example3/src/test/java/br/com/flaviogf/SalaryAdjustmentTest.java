package br.com.flaviogf;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

import java.math.BigDecimal;

import org.junit.jupiter.api.Test;

public class SalaryAdjustmentTest {
  @Test
  public void applyIncreasesTheSalaryByTheSpecifyPerformance() {
    Employee employee = new Employee("Frank", new BigDecimal("1000.00"));

    Performance performance = mock(Performance.class);
    when(performance.apply(any())).thenReturn(new BigDecimal("1003.00"));

    employee = new SalaryAdjustment(employee, performance).apply();

    assertEquals(employee.getSalary(), new BigDecimal("1003.00"));
  }
}
