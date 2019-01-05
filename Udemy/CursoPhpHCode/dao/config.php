<?php

spl_autoload_register(function($className) {
  $filename = "$className.php";
  if(file_exists($filename)) {
    require_once $filename;
  }
});
