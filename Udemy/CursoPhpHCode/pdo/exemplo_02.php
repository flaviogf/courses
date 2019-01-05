<?php

$conn = new PDO("mysql:dbname=php01;host=localhost", "root", "");

$stmt = $conn->prepare("UPDATE usuarios SET nome = :nome, sobrenome = :sobrenome WHERE id = :id");

$id = 2;
$nome = "luis fernando";
$sobrenome = "fernandes";

$stmt->bindParam(":nome", $nome);
$stmt->bindParam(":sobrenome", $sobrenome);
$stmt->bindParam(":id", $id);

$stmt->execute();

echo "Atualizado";
