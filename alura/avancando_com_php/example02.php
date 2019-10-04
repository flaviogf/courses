<?php

$flavio = [
  "name" => "Flavio",
  "email" => "flavio@email.com"
];

$fernando = [
  "name" => "Fernando",
  "email" => "fernando@email.com"
];

$accounts  = [
  '123.456.789-10' => $flavio,
  '987.654.321-10' => $fernando
];

foreach($accounts as $cpf => $account) {
  $name = $account["name"];
  $email = $account["email"];
  echo "$cpf => $name - $email" . PHP_EOL;
}
