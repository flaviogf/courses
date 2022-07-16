package main

import (
	"database/sql"
	"log"

	_ "github.com/lib/pq"
)

func main() {
	connStr := "user=postgres password=postgres port=54320 dbname=store sslmode=disable"
	conn, err := sql.Open("postgres", connStr)

	if err != nil {
		log.Fatalln(err)
	}

	if err = conn.Ping(); err != nil {
		log.Fatalln(err)
	}

	log.Println("It works")
}
