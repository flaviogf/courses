<?php
function __autoload($classe) {
  require_once "$classe.php";
}

spl_autoload_register(function ($classe) {
  $arquivo = __DIR__.DIRECTORY_SEPARATOR."$classe.php";
  if(file_exists($arquivo)) {
    require_once $arquivo;
  }
});
