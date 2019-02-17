<?php

$folder = "images";

if(!is_dir($folder)) {
  mkdir($folder);
  echo "Diretorio $folder criado";
}

$arquivos = array_filter(scandir("images"), function($nome) {
  return !preg_match("/^\.{1,2}$/", $nome);
});

$infos = array();

foreach($arquivos as $it) {
  $filename = "images".DIRECTORY_SEPARATOR.$it;
  $info = pathinfo($filename);
  $size = filesize($filename);
  $modify = date("d-m-Y H:i:s", fileatime($filename));
  $arquivo = array(
    "filename" => $filename,
    "modify" => $modify,
    "size" => $size
  );
  array_push($infos, $arquivo);
}

echo json_encode($infos);
