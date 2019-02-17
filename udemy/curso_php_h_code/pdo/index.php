<?php

$dbh = new PDO("mysql:host=localhost;dbname=php01", "root", "");

$rows = $dbh->query("SELECT * FROM usuarios")->fetchAll(PDO::FETCH_ASSOC);

echo json_encode($rows);
