<?php

interface Veiculo {
  function acelera();
}

abstract class Automovel implements Veiculo {
  abstract function desliga();

  function acelera() {
    echo "Acelerando";
  }
}

class Civic extends Automovel {
  function desliga() {
    echo  "Desligando";
  }
}

(new Civic)->acelera();
echo "<br>";
(new Civic)->desliga();
