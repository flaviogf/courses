<?php

require_once "autoload.php";

use Bank\Models\Account;
use Bank\Models\Developer;
use Bank\Models\Document;
use Bank\Models\Employee;
use Bank\Models\Holder;
use Bank\Models\Manager;
use Bank\Services\BonusCalculator;

$account = new Account(new Holder("Frank", new Document("123")));

$account->deposit(1500);
$account->deposit(1500);
$account->withdraw(500);

echo $account->getBalance();

echo "\n";

$calculator = new BonusCalculator();

echo $calculator->execute(
    new Developer("Frank", new Document("123"), 1000),
    new Manager("Tank", new Document("456"), 1000),
);

echo "\n";