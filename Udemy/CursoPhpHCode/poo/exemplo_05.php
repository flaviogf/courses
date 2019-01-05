<?php

interface Veiculo {
  function acelera($velocidade);
}

class Civic implements Veiculo {

  function acelera($velocidade) {
    echo "Civic acelerando $velocidade";
  }
}

(new Civic)->acelera(100);
