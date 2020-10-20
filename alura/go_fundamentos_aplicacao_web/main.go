package main

import (
	"database/sql"
	"log"
	"net/http"
	"text/template"

	_ "github.com/lib/pq"
)

type Product struct {
	Id          int32
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
	db, err := openConnection()

	if err != nil {
		log.Fatal(err)
	}

	var product Product

	var products []Product

	row, err := db.Query("SELECT * FROM products")

	if err != nil {
		log.Fatal(err)
	}

	for row.Next() {
		row.Scan(&product.Id, &product.Name, &product.Description, &product.Price, &product.Quantity)

		products = append(products, product)
	}

	t.ExecuteTemplate(wr, "Index", products)
}

func openConnection() (*sql.DB, error) {
	connectionString := "postgres://postgres:postgres@localhost/alura_loja?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)

	return db, err
}
