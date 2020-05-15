<?php

class Account
{
  private Holder $holder;
  private string $number;
  private float $balance;

  public function __construct(Holder $holder, string $number)
  {
    $this->holder = $holder;
    $this->number = $number;
    $this->balance = 0;
  }

  public function deposit(float $value): void
  {
    $this->balance += $value;
  }

  public function withdraw(float $value): void
  {
    $this->balance -= $value;
  }

  public function balance(): float
  {
    return $this->balance;
  }
}