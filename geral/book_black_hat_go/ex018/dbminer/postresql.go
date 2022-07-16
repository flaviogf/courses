package dbminer

import (
	"context"
	"database/sql"
	"log"
	"time"

	_ "github.com/lib/pq"
)

type PostgreSQLMiner struct {
}

func NewPostgreSQLMiner() *PostgreSQLMiner {
	return &PostgreSQLMiner{}
}

func (pq *PostgreSQLMiner) GetSchema() (*Schema, error) {
	var result Schema

	connStr := "user=postgres password=postgres port=54320 sslmode=disable"
	conn, err := sql.Open("postgres", connStr)

	if err != nil {
		log.Fatalln(err)
	}

	if err = conn.Ping(); err != nil {
		log.Fatalln(err)
	}

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	query := "SELECT datname FROM pg_database;"

	rows, err := conn.QueryContext(ctx, query)

	if err != nil {
		log.Fatalln(err)
	}

	defer rows.Close()

	for rows.Next() {
		var database Database

		if err = rows.Scan(&database.Name); err != nil {
			log.Fatalln(err)
		}

		result.Databases = append(result.Databases, database)
	}

	return &result, nil
}
