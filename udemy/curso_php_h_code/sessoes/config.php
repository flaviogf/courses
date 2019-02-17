<?php
session_start();
$_SESSION["ACESSO"] = time();
echo session_id() . "<br>";
