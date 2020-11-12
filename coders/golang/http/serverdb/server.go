package main

import (
	"database/sql"
	"encoding/json"
	"log"
	"net/http"

	_ "github.com/go-sql-driver/mysql"
)

type Usuario struct {
	ID   int
	Nome string
}

func main() {
	http.HandleFunc("/usuarios/", usuarioHandler)

	log.Println("Executando...")

	log.Fatal(http.ListenAndServe(":3000", nil))
}

func usuarioHandler(w http.ResponseWriter, r *http.Request) {
	db, err := sql.Open("mysql", "root:root@/cursogo")

	if err != nil {
		log.Fatal(err)
	}

	rows, _ := db.Query("select id, nome from usuarios")

	var usuarios []Usuario

	for rows.Next() {
		var usuario Usuario

		rows.Scan(&usuario.ID, &usuario.Nome)

		usuarios = append(usuarios, usuario)
	}

	bytes, _ := json.Marshal(usuarios)

	w.Header().Add("Content-Type", "application/json")

	w.Write(bytes)
}
