<?php

namespace HandlingCollections;

class Calculator
{
    public function average(float ...$grades): float
    {
        $sum = 0;

        foreach($grades as $grade)
        {
            $sum += $grade;
        }

        return $sum / count($grades);
    }
}
