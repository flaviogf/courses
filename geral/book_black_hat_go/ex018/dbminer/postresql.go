package dbminer

import (
	"database/sql"
	"log"

	_ "github.com/lib/pq"
)

type PostgreSQLMiner struct {
}

func NewPostgreSQLMiner() *PostgreSQLMiner {
	return &PostgreSQLMiner{}
}

func (pq *PostgreSQLMiner) GetSchema() (*Schema, error) {
	connStr := "user=postgres password=postgres port=54320 sslmode=disable"
	conn, err := sql.Open("postgres", connStr)

	if err != nil {
		log.Fatalln(err)
	}

	if err = conn.Ping(); err != nil {
		log.Fatalln(err)
	}

	return &Schema{}, nil
}
