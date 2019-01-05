<?php

$nome =  "flavio";

function teste1(&$valor) {
  $valor = "Olá $valor!<br>";
  echo $valor;
}

teste1($nome);

echo $nome;

$pessoa = array(
  "nome" => "flavio",
  "idade" => 21
);

print_r($pessoa);

foreach ($pessoa as $key => &$value) {
  if(gettype($value) === "integer") {
    $value += 10;
  }
}

print_r($pessoa);
