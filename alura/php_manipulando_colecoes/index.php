<?php

require 'Calculator.php';

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

echo "<ol>";
