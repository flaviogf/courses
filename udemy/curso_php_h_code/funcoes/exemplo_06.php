<?php

function teste($callback) {
  echo "Inicio<br>";
  $callback();
  echo "Fim<br>";
}

teste(function() {
  echo "Processando<br>";
});
