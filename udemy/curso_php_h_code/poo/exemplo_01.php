<?php

class Pessoa {

  public $nome;

  public function fala() {
    return "Olá $this->nome";
  }
}

$flavio = new Pessoa();
$flavio->nome = "Flávio";
echo $flavio->fala();
