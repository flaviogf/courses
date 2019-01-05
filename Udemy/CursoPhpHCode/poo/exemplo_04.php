<?php

class Documento {

  private $numero;

  public function getNumero(): string {
    return $this->numero;
  }

  public function setNumero($value) {
    $this->numero = $value;
  }
}

class CPF extends Documento {

  public function valida() {
    return strlen($this->getNumero()) === 11;
  }
}

$cpf = new CPF();
$cpf->setNumero("12345678911");
var_dump($cpf->valida());
$cpf->setNumero("123456789112");
var_dump($cpf->valida());
