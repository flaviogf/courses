<?php

setlocale(LC_ALL, "pt_BR.utf-8");

date_default_timezone_set("America/Sao_Paulo");

$hj = new DateTime();

$hjMais15Dias = new DateInterval("P15D");

echo $hj->format("d/m/Y H:i:s");

echo "<br>";

$hj->add($hjMais15Dias);

echo $hj->format("d/m/Y H:i:s");
