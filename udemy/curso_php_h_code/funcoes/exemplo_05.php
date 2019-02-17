<?php

$hierarquia = array(
  array(
    "nome_cargo" => "CEO 1",
    "subordinados" => array(
      array(
        "nome_cargo" => "Gerente 1-1"
      ),
      array(
        "nome_cargo" => "Gerente 1-2"
      )
    )
  ),
  array(
    "nome_cargo" => "CEO 2",
    "subordinados" => array(
      array(
        "nome_cargo" => "Gerente 2-1"
      ),
      array(
        "nome_cargo" => "Gerente 2-2"
      )
    )
  )
);

function exibe($cargos): string {
  $html = "<ul>";

  foreach($cargos as $it) {
    $html .= "<li>";
    $html .= $it["nome_cargo"];

    if(isset($it["subordinados"]) && count($it["subordinados"]) > 0) {
      $html .= exibe($it["subordinados"]);
    }

    $html .= "</li>";
  }

  $html .= "</ul>";

  return $html;
}

echo exibe($hierarquia);
