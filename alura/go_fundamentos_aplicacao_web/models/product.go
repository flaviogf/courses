package models

import (
	"log"

	"github.com/flaviogf/go_fundamentos_aplicacao_web/database"
)

type Product struct {
	Id          int
	Name        string
	Description string
	Price       float64
	Quantity    int
}

func Find() []Product {
	db, err := database.OpenConnection()

	if err != nil {
		log.Fatal(err)
	}

	rows, err := db.Query("SELECT * FROM products")

	if err != nil {
		log.Fatal(err)
	}

	var products []Product

	var product Product

	for rows.Next() {
		rows.Scan(&product.Id, &product.Name, &product.Description, &product.Price, &product.Quantity)

		products = append(products, product)
	}

	return products
}

func Create(name string, description string, price float64, quantity int) Product {
	product := Product{
		0,
		name,
		description,
		price,
		quantity,
	}

	return product
}
