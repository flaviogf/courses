<?php

namespace Bank\Models;

class Manager extends Employee implements Authenticable
{
    use PropertyAccessor;

    public function getBonus(): float
    {
        return $this->getSalary();
    }

    public function attempt(string $password): bool
    {
        return $password === "123";
    }
}