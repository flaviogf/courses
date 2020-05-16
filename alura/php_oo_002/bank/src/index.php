<?php

require_once "autoload.php";

use Bank\Models\Account;
use Bank\Models\Developer;
use Bank\Models\Document;
use Bank\Models\Employee;
use Bank\Models\Holder;
use Bank\Models\Manager;
use Bank\Services\Authenticator;
use Bank\Services\BonusCalculator;

$account = new Account(new Holder("Frank", new Document("123")));

$account->deposit(1500);
$account->deposit(1500);
$account->withdraw(500);

$result = $account->getBalance();

var_dump($result);

$calculator = new BonusCalculator();

$employees = [new Developer("Frank", new Document("123"), 1000), new Manager("Tank", new Document("456"), 1000)];

$result = $calculator->execute(...$employees);

var_dump($result);

$authenticator = new Authenticator();

$result = $authenticator->attempt(new Manager("Tank", new Document("456"), 1000), "1234");

var_dump($result);

$manager = new Manager("Tank", new Document("456"), 1000);

var_dump($manager->name);
var_dump($manager->document);
var_dump($manager->salary);
var_dump($manger->bonus);
