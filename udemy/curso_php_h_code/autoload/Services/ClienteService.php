<?php
namespace Services;

use Models\Cliente;

class ClienteService {

  public function insere(Cliente $cliente) {
    echo "Inserindo $cliente";
  }
}
