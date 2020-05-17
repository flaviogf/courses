<?php

require_once 'autoload.php';

use HandlingCollections\Arrays;
use HandlingCollections\Calculator;

$calculator = new Calculator();

$average = $calculator->average(10, 10, 9);

var_dump($average);

$numbers = [10, 10, 9];

echo "<ol>";

foreach($numbers as $number)
{
    echo "<li>{$number}</li>";
}

echo "</ol>";

$names = "Frank;Tank;Rex";

echo "<ol>";

foreach(explode(";", $names) as $name)
{
    echo "<li>{$name}</li>";
}

echo "</ol>";

$numbers = [1, 2, 3, 4, 5];

echo "<pre>";

var_dump($numbers);

echo "</pre>";

Arrays::remove($numbers, 3);

echo "<pre>";

var_dump($numbers);

echo "</pre>";

$names = ["Frank", "Rex", "Nina"];
$ages = [2, 11, 10];
$dogs = array_combine($names, $ages);

echo "<ul>";

foreach($dogs as $name => $age) {
    echo "<li>{$name} {$age}</li>";
}

echo "</ul>";
