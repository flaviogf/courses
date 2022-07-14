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
	Amount uint32
	CVV    string
	Exp    time.Time
}

func main() {
	connStr := "user=postgres password=postgres dbname=store port=54320 sslmode=disable"
	db, err := sql.Open("postgres", connStr)

	if err != nil {
		log.Fatalln(err)
	}

	if err = db.Ping(); err != nil {
		log.Fatalln(err)
	}

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	conn, err := db.Conn(ctx)

	if err != nil {
		log.Fatalln(err)
	}

	const format = "2006-01-02"

	date, _ := time.Parse(format, "2019-01-05")
	exp, _ := time.Parse(format, "2020-09-01")

	transactions := []Transaction{
		Transaction{
			"4444333322221111",
			date,
			10012,
			"1234",
			exp,
		},
	}

	query := "INSERT INTO public.transactions(ccnum, date, amount, cvv, exp) VALUES ($1, $2, $3, $4, $5)"

	for _, t := range transactions {
		result, err := conn.ExecContext(ctx, query, t.CCNum, t.Date, t.Amount, t.CVV, t.Exp)

		if err != nil {
			log.Fatalln(err)
		}

		rows, err := result.RowsAffected()

		if err != nil {
			log.Fatalln(err)
		}

		if rows != 1 {
			log.Fatalf("expected single row affected, got: %d rows affected\n", rows)
		}
	}
}
