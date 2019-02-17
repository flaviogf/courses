<?php

require_once 'vendor/autoload.php';

use Monolog\Logger;
use Monolog\Handler\StreamHandler;

$log = new Logger("teste");
$log->pushHandler(new StreamHandler("php.log", Logger::WARNING));

$log->warning("teste");
$log->error("TESTE");
