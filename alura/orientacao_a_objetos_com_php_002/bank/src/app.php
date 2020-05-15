<?php

require_once "autoload.php";

use Bank\Models\Holder;
use Bank\Models\Account;

$holder = new Holder("Frank");

$account = new Account($holder);

$account->deposit(1500);

echo $account->getBalance();