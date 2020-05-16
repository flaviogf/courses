<?php

function summary($account)
{
  return "Account[name={$account['name']}, balance={$account['balance']}]" . PHP_EOL;
}

function withdraw(&$account, $value)
{
  $account['balance'] -= $value;

  return $account;
}

$account = ["name" => "Flavio", "balance" => 3000];

echo summary($account);

withdraw($account, 100);

echo summary($account);
