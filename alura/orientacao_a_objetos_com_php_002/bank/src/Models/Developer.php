<?php

namespace Bank\Models;

class Developer extends Employee
{
    public function getBonus(): float
    {
        return $this->getSalary() * 0.5;
    }
}