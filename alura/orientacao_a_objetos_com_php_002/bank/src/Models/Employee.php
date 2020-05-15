<?php

namespace Bank\Models;

abstract class Employee extends Person
{
    private float $salary;

    public function __construct(string $name, Document $document, float $salary)
    {
        parent::__construct($name, $document);
        $this->salary = $salary;
    }

    public function getSalary(): float
    {
        return $this->salary;
    }

    abstract public function getBonus(): float;
}