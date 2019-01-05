<?php

$pdo = new PDO("mysql:host=localhost;dbname=php01", "root", "");

$stmt = $pdo->query("SELECT * FROM usuarios");

$usuarios = $stmt->fetchAll(PDO::FETCH_ASSOC);

$headers = implode(",", array_keys($usuarios[0]))."\r\n";

$nomeArquivo = "usuarios.csv";

unlink($nomeArquivo);

$arquivo = fopen($nomeArquivo, "w");

fwrite($arquivo, $headers);

foreach($usuarios as $value) {
  fwrite($arquivo, implode(",", array_values($value))."\r\n");
}

fclose($arquivo);

echo "$nomeArquivo atualizado";
