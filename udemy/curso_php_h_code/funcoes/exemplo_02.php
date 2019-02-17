<?php

function soma() {
  $soma = 0;
  foreach (func_get_args() as $value) {
    $soma += $value;
  }
  return $soma;
}

echo soma(10, 10, 20);
