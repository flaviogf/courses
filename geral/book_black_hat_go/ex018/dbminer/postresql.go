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

	connStr := "user=postgres password=postgres port=54320 dbname=store sslmode=disable"
	conn, err := sql.Open("postgres", connStr)

	if err != nil {
		log.Fatalln(err)
	}

	if err = conn.Ping(); err != nil {
		log.Fatalln(err)
	}

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	query := "SELECT table_schema, table_name, column_name FROM information_schema.columns WHERE table_schema NOT IN ('information_schema', 'pg_catalog');"

	rows, err := conn.QueryContext(ctx, query)

	if err != nil {
		log.Fatalln(err)
	}

	defer rows.Close()

	for rows.Next() {
		var currschema, currtable, currcol string

		if err = rows.Scan(&currschema, &currtable, &currcol); err != nil {
			log.Fatalln(err)
		}

		log.Println(currschema)
		log.Println(currtable)
		log.Println(currcol)
	}

	return &result, nil
}
