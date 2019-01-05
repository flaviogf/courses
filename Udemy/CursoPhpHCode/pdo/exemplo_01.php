<?php

$conn = new PDO("mysql:dbname=php01;host=localhost", "root", "");

$stmt = $conn->prepare("INSERT INTO usuarios(nome, sobrenome) VALUES (:nome, :sobrenome)");

$nome = "fernando";
$sobrenome = "fernandes";

$stmt->bindParam(":nome", $nome);
$stmt->bindParam(":sobrenome", $sobrenome);

$stmt->execute();

echo "$nome inserido";
