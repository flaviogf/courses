package main

import (
	"database/sql"
	"log"
	"net/http"
	"text/template"

	_ "github.com/lib/pq"
)

type Product struct {
	Name        string
	Description string
	Price       float64
	Quantity    int32
}

var t = template.Must(template.ParseGlob("templates/*.html"))

func main() {
	db, err := openConnection()

	if err != nil {
		log.Fatal(err)
	}

	defer db.Close()

	http.HandleFunc("/", index)

	http.ListenAndServe(":8000", nil)
}

func index(wr http.ResponseWriter, r *http.Request) {
	products := []Product{
		{Name: "Camiseta", Description: "Bem bonita", Price: 39.99, Quantity: 100},
	}

	t.ExecuteTemplate(wr, "Index", products)
}

func openConnection() (*sql.DB, error) {
	connectionString := "postgres://postgres:postgres@localhost/alura_loja"

	db, err := sql.Open("postgres", connectionString)

	return db, err
}
