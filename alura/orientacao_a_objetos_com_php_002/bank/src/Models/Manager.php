<?php

namespace Bank\Models;

class Manager extends Employee
{
    public function getBonus(): float
    {
        return $this->getSalary();
    }
}