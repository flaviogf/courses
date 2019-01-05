<?php

class Endereco {
  private $rua;
  private $numero;

  public function __construct($rua, $numero) {
    $this->rua = $rua;
    $this->numero = $numero;
  }

  public function __toString() {
    return "Rua: $this->rua, Numero: $this->numero";
  }

  public function __destruct() {
    echo "destruindo objeto";
  }

  public function __set($name, $value) {
    if(strpos($name, "rua") !== false) {
      $this->rua = $value;
    }
    if(strpos($name, "numero") !== false) {
      $this->numero = $value;
    }
    echo "SET: $name <br>";
  }
}

$end = new Endereco("Teste", "1");

$end->rua = "Teste1";

$end->numero = "1010";

echo $end;

echo "<br>";
