package main

import (
	"io/ioutil"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()

	r.HandleFunc("/products", ListProductsHandler)

	http.ListenAndServe(":8080", r)
}

func ListProductsHandler(w http.ResponseWriter, r *http.Request) {
	file, _ := os.Open("products.json")

	defer file.Close()

	products, _ := ioutil.ReadAll(file)

	w.Write([]byte(products))
}

type Product struct {
	Uuid    string  `json:"uuid"`
	Product string  `json:"product"`
	Price   float64 `json:"price,string"`
}

type Products struct {
	Products []Product
}
