<?php

require_once 'config.php';

// $sql = new Sql();
//
// $usuarios = $sql->select("SELECT * FROM usuarios");
//
// $usuario = new Usuario();
//
// $usuario->loadById(1);
//
// echo "<p>Usuario</p>";
//
// echo $usuario;
//
// echo "<p>Usuarios</p>";
//
// echo json_encode($usuarios);
//
// echo "<p>Usuarios</p>";
//
// echo json_encode(Usuario::list());
//
// echo "<p>Usuarios</p>";
//
// echo json_encode(Usuario::search("fe"));

$usuario = new Usuario();

$usuario->loadById(1);

$usuario->update("teste", "teste");

echo $usuario;
