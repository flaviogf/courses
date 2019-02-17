<?php
$meses = array(
  "Janeiro", "Fevereiro", "Março",
  "Abril", "Maio", "Junho",
  "Julho", "Agosto", "Setembro",
  "Outubro", "Novembro", "Dezembro"
);

echo "<select>";
for ($i = 0; $i < count($meses); $i+=1) {
  echo "<option value='$i'>$meses[$i]</option>";
}
echo "</select>";

echo "<select>";
foreach ($meses as $key => $value) {
  echo "<option value='$key'>$value</option>";
}
echo "</select>";
