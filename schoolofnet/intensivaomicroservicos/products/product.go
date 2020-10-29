package main

import (
	"encoding/json"
	"io/ioutil"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()

	r.HandleFunc("/products", ListProductsHandler)

	r.HandleFunc("/products/{id}", GetProductHandler)

	http.ListenAndServe(":8080", r)
}

func ListProductsHandler(w http.ResponseWriter, r *http.Request) {
	file, _ := os.Open("products.json")

	defer file.Close()

	products, _ := ioutil.ReadAll(file)

	w.Write([]byte(products))
}

func GetProductHandler(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	file, _ := os.Open("products.json")

	defer file.Close()

	items, _ := ioutil.ReadAll(file)

	var products Products

	json.Unmarshal(items, &products)

	for _, it := range products.Products {
		if vars["id"] == it.UUID {
			product, _ := json.Marshal(it)
			w.Write([]byte(product))
		}
	}
}

type Product struct {
	UUID    string  `json:"uuid"`
	Product string  `json:"product"`
	Price   float64 `json:"price,string"`
}

type Products struct {
	Products []Product
}
