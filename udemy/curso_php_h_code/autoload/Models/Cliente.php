<?php
namespace Models;

class Cliente {
  public function __construct($nome) {
    $this->nome = $nome;
  }

  public function __toString() {
    return "Cliente(Nome=$this->nome)";
  }
}
