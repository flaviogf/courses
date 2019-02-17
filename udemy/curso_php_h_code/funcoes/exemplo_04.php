<?php

function somaInteiros(int ...$numeros): int {
  return array_sum($numeros);
}

echo somaInteiros(10, 20, 30.5);
