<?php

spl_autoload_register(function(string $name) {
    $path = str_replace("Bank", "src", $name);
    $path = join(DIRECTORY_SEPARATOR, explode("\\", $path));
    $path = "${path}.php";

    if(!file_exists($path)) return;

    require_once $path;
});