package br.com.flaviogf;

import java.math.BigDecimal;

public class Employee {
	private final String name;
	private final BigDecimal salary;

	public Employee(String name, BigDecimal salary) {
    this.name = name;
    this.salary = salary;
	}

	public String getName() {
		return name;
	}

	public BigDecimal getSalary() {
		return salary;
	}
}
