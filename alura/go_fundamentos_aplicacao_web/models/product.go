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

func Create(name string, description string, price float64, quantity int) {
	db, err := database.OpenConnection()

	if err != nil {
		log.Fatal(err)
	}

	stmt, err := db.Prepare("INSERT INTO products (name, description, price, quantity) VALUES ($1, $2, $3, $4)")

	if err != nil {
		log.Fatal(err)
	}

	stmt.Exec(name, description, price, quantity)

	defer db.Close()
}

func Delete(id int) {
	db, err := database.OpenConnection()

	if err != nil {
		log.Fatal(err)
	}

	stmt, err := db.Prepare("DELETE FROM products WHERE id = $1")

	if err != nil {
		log.Fatal(err)
	}

	stmt.Exec(id)
}

func FindOne(id int) Product {
	db, err := database.OpenConnection()

	if err != nil {
		log.Fatal(err)
	}

	rows, err := db.Query("SELECT * FROM products WHERE id = $1", id)

	if err != nil {
		log.Fatal(err)
	}

	rows.Next()

	var product Product

	err = rows.Scan(&product.Id, &product.Name, &product.Description, &product.Price, &product.Quantity)

	if err != nil {
		log.Fatal(err)
	}

	return product
}
