<?php

namespace Bank\Services;

use Bank\Models\Employee;

class BonusCalculator
{
    public function execute(Employee ...$employees): float
    {
        $total = 0;

        foreach($employees as $employee)
        {
            $total += $employee->getBonus();
        }

        return $total;
    }
}