<form method="POST" enctype="multipart/form-data">

  <input type="file" class="form-control" name="imagem">

  <button>Enviar</button>
</form>

<?php

if($_SERVER["REQUEST_METHOD"] === "POST") {

  $imagens = "imagens";

  if(!is_dir($imagens)) {
    mkdir($imagens);
  }

  $file = $_FILES["imagem"];

  if(move_uploaded_file($file["tmp_name"], $imagens.DIRECTORY_SEPARATOR.$file["name"])) {
    echo "Upload realizado com sucesso";
  } else {
    echo "Erro ao realizar o upload";
  }

}
