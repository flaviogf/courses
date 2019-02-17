<?php
$nome = "flavio";

$mensagem = "Nome: $nome";

echo "<br>";

echo strtoupper($mensagem);

echo "<br>";

echo strtolower($mensagem);

echo "<br>";

echo ucwords($mensagem);

echo "<br>";

echo ucfirst($mensagem);

echo "<br>";

echo substr($mensagem, 0, 3);

echo "<br>";

echo ucfirst(substr($mensagem, 6));

echo "<br>";

echo strpos($mensagem, "a");

echo "<br>";

echo strlen($mensagem);
