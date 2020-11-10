package main

import (
	"database/sql"

	_ "github.com/go-sql-driver/mysql"
)

func main() {
	db, err := sql.Open("mysql", "root:root@/cursogo")

	if err != nil {
		panic(err)
	}

	stmt, _ := db.Prepare("update usuarios set nome = ? where id = ?")

	stmt.Exec("Uóxiton Istive", 1)
	stmt.Exec("Sheristone Uasleka", 2)

	stmt, _ = db.Prepare("delete from usuarios where id = ?")
	stmt.Exec(3)
}
