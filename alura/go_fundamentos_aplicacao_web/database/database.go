package database

import "database/sql"

func OpenConnection() (*sql.DB, error) {
	connectionString := "postgres://postgres:postgres@localhost/alura_loja?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)

	return db, err
}
