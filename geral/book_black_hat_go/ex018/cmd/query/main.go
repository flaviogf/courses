package main

import (
	"context"
	"database/sql"
	"log"
	"time"

	_ "github.com/lib/pq"
)

type Transaction struct {
	CCNum  string
	Date   time.Time
	Amount float64
	CVV    string
	Exp    time.Time
}

func main() {
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

	query := "SELECT ccnum, date, amount::decimal, cvv, exp FROM public.transactions"

	rows, err := conn.QueryContext(ctx, query)

	if err != nil {
		log.Fatalln(err)
	}

	defer rows.Close()

	var t Transaction

	for rows.Next() {
		err = rows.Scan(&t.CCNum, &t.Date, &t.Amount, &t.CVV, &t.Exp)

		if err != nil {
			log.Fatalln(err)
		}

		log.Printf("%v", t)
	}
}
