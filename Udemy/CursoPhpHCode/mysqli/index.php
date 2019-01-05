<?php

$conn = new mysqli("localhost", "root", "", "php01");

$stm = $conn->prepare("INSERT INTO usuarios(nome, sobrenome) VALUES (?, ?)");

$nome = "flavio";
$sobrenome = "fernandes";

$stm->bind_param("ss", $nome, $sobrenome);

$stm->execute();

echo "$nome inserido";
