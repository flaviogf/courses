<?php

$flavio = [
  "name" => "Flavio",
  "email" => "flavio@email.com"
];

$fernando = [
  "name" => "Fernando",
  "email" => "fernando@email.com"
];

$accounts  = [$flavio, $fernando];

foreach($accounts as $account) {
  $name = $account["name"];
  $email = $account["email"];
  echo "$name => $email" . PHP_EOL;
}
