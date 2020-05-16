<?php

namespace Bank\Models;

class Account
{
    private Holder $holder;
    private float $balance;

    public function __construct(Holder $holder)
    {
        $this->holder = $holder;
        $this->balance = 0;
    }

    public function getBalance(): float
    {
        return $this->balance;
    }

    public function deposit(float $value): void
    {
        $this->balance += $value;
    }

    public function withdraw(float $value): void
    {
        $this->balance -= $value;
    }
}