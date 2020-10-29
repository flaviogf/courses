package main

import (
	"encoding/json"
	"html/template"
	"io/ioutil"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()

	r.HandleFunc("/{id}", DisplayCheckout)

	http.ListenAndServe(":8082", r)
}

func DisplayCheckout(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	url := os.Getenv("PRODUCT_URL")

	resp, _ := http.Get(url + "/products/" + vars["id"])

	item, _ := ioutil.ReadAll(resp.Body)

	var product Product

	json.Unmarshal(item, &product)

	t := template.Must(template.ParseGlob("./templates/*.html"))

	t.ExecuteTemplate(w, "Checkout", product)
}

type Product struct {
	UUID    string  `json:"uuid"`
	Product string  `json:"product"`
	Price   float64 `json:"price,string"`
}
