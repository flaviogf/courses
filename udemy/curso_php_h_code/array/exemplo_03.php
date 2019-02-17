<?php
$pessoas = array();

$pessoa1 = array('nome' => 'flavio', 'sobrenome' => 'fernandes' );
$pessoa2 = array('nome' => 'fernando', 'sobrenome' => 'fernandes' );

array_push($pessoas, $pessoa1);
array_push($pessoas, $pessoa2);

print_r($pessoas);
