package main

import (
	"net/http"
	"text/template"
)

type Product struct {
	Name        string
	Description string
	Price       float64
	Quantity    int32
}

var t = template.Must(template.ParseGlob("templates/*.html"))

func main() {
	http.HandleFunc("/", index)

	http.ListenAndServe(":8000", nil)
}

func index(wr http.ResponseWriter, r *http.Request) {
	products := []Product{
		{Name: "Camiseta", Description: "Bem bonita", Price: 39.99, Quantity: 100},
	}

	t.ExecuteTemplate(wr, "Index", products)
}
