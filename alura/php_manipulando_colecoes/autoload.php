<?php

spl_autoload_register(function(string $name) {
    $path = str_replace("HandlingCollections", "src", $name);
    $path = str_replace("\\", DIRECTORY_SEPARATOR, $path);
    $path = $path . ".php";
    if(!file_exists($path)) return;
    require_once $path;
});
