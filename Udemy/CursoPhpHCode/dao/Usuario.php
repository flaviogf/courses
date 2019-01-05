<?php

class Usuario {

  private $id;
  private $nome;
  private $sobrenome;
  private $dataCadastro;

  public function __construct($nome = "", $sobrenome = "") {
    $this->nome = $nome;
    $this->sobrenome = $sobrenome;
  }

  public function loadById($id) {
    $sql = new Sql();
    $results = $sql->select("SELECT * FROM usuarios WHERE id = :id", array(":id" => $id));
    $this->setData($results);
  }

  public function insert() {
    $sql = new Sql();
    $results = $sql->select("CALL sp_usuarios_insert(:nome, :sobrenome)", array(":nome" => $this->nome, ":sobrenome" => $this->sobrenome));
    $this->setData($results);
  }

  public function update($nome, $sobrenome) {
    $this->nome = $nome;
    $this->sobrenome = $sobrenome;
    $sql = new Sql();
    $sql->query("UPDATE usuarios SET nome = :nome, sobrenome = :sobrenome WHERE id = :id", array(
      ":nome" => $nome,
      ":sobrenome" => $sobrenome,
      ":id" => $this->id
    ));
  }

  private function setData($results) {
    if(count($results) <= 0) return;
    $row = $results[0];
    $this->id = $row["id"];
    $this->nome = $row["nome"];
    $this->sobrenome = $row["sobrenome"];
    $this->dataCadastro = new DateTime($row["dataCadastro"]);
  }

  public static function list() {
    $sql = new Sql();
    return $sql->select("SELECT * FROM usuarios");
  }

  public static function search($nome) {
    $sql = new Sql();
    return $sql->select("SELECT * FROM usuarios WHERE nome LIKE :search", array(":search" => "%$nome%"));
  }

  public function __toString() {
    return json_encode(array(
      "id" => $this->id,
      "nome" => $this->nome,
      "sobrenome" => $this->sobrenome,
      "dataCadastro" => $this->dataCadastro->format("d-m-Y H:i:s")
    ));
  }
}
