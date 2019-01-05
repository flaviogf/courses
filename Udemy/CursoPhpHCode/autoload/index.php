<?php
require_once "config.php";

use Models\Cliente;
use Services\ClienteService;

$service = new ClienteService();
$service->insere(new Cliente("Flavio"));
