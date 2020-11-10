package main

import (
	"database/sql"
	"fmt"

	_ "github.com/go-sql-driver/mysql"
)

func main() {
	db, err := sql.Open("mysql", "root:root@/cursogo")

	if err != nil {
		panic(err)
	}

	defer db.Close()

	stmt, _ := db.Prepare("insert into usuarios(nome) values(?)")

	stmt.Exec("Maria")
	stmt.Exec("João")

	result, _ := stmt.Exec("Pedro")

	id, _ := result.LastInsertId()

	fmt.Println(id)

	linha, _ := result.RowsAffected()

	fmt.Println(linha)
}
