<?php

$nome = "Flávio";

$sobrenome = "Fernandes";

$nomeCompleto = $nome . " " . $sobrenome;

echo $nomeCompleto;

unset($nome);

if(isset($nome)) {
  echo $nome;
}

$arquivo = fopen('exemplo_02.php', 'r');

echo $arquivo;

var_dump($arquivo);
