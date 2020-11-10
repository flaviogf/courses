package main

import (
	"database/sql"
	"fmt"

	_ "github.com/go-sql-driver/mysql"
)

type Usuario struct {
	id   int
	nome string
}

func main() {
	db, err := sql.Open("mysql", "root:root@/cursogo")

	if err != nil {
		panic(err)
	}

	defer db.Close()

	rows, _ := db.Query("select * from usuarios")

	for rows.Next() {
		var usuario Usuario

		rows.Scan(&usuario.id, &usuario.nome)

		fmt.Println(usuario)
	}
}
