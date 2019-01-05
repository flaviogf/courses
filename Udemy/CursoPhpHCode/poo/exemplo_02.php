<?php

class Validadores {

  public static function cpfValido(string $cpf): bool {
    return strlen($cpf) === 11;
  }
}

var_dump(Validadores::cpfValido("12345678911"));
var_dump(Validadores::cpfValido("1234567891"));
