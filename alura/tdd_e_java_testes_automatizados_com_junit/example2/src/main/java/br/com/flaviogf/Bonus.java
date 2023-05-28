package br.com.flaviogf;

import java.math.BigDecimal;

public class Bonus {
	private final Employee employee;

	public Bonus(Employee employee) {
    this.employee = employee;
	}

	public BigDecimal getValue() {
		return new BigDecimal("250.00");
	}
}
