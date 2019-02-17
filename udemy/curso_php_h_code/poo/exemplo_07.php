<?php
interface iAutenticavel {
  function autentica();
}

abstract class Funcionario implements iAutenticavel {
}

class Programador extends Funcionario {
  function autentica() {
    echo "Programador autenticando";
  }
}

class Cliente implements iAutenticavel {
  function autentica() {
    echo "Cliente autenticando";
  }
}

function autentica(iAutenticavel $usuario) {
  $usuario->autentica();
  echo "<br>";
}

autentica(new Programador());
autentica(new Cliente());
