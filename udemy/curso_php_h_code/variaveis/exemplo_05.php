<?php

$nome = "Flávio";

function teste() {
  global $nome;
  echo "Teste 1 <br />";
  echo $nome . "<br />";
}

function teste2() {
  echo "Teste 2 <br />";
  echo $nome . "<br />";
}

teste();
teste2();
