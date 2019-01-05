<?php

class Sql {

  private $conn;

  public function __construct() {
    $this->conn = new PDO("mysql:dbname=php01;host=localhost", "root", "");
  }

  public function query($rawQuery, $params = array()) {
    $stmt = $this->conn->prepare($rawQuery);
    $stmt->execute($params);
    return $stmt;
  }

  public function select($rawQuery, $params = array()) {
    $stmt = $this->query($rawQuery, $params);
    return $stmt->fetchAll(PDO::FETCH_ASSOC);
  }
}
