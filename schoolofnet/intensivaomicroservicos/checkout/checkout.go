package main

import (
	"encoding/json"
	"fmt"
	"html/template"
	"io/ioutil"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()

	r.HandleFunc("/finish", FinishHandler)

	r.HandleFunc("/{id}", DisplayCheckoutHandler)

	http.ListenAndServe(":8082", r)
}

func DisplayCheckoutHandler(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	url := os.Getenv("PRODUCT_URL")

	resp, _ := http.Get(url + "/products/" + vars["id"])

	item, _ := ioutil.ReadAll(resp.Body)

	var product Product

	json.Unmarshal(item, &product)

	t := template.Must(template.ParseGlob("./templates/*.html"))

	t.ExecuteTemplate(w, "Checkout", product)
}

func FinishHandler(w http.ResponseWriter, r *http.Request) {
	var order Order
	order.Name = r.FormValue("name")
	order.Email = r.FormValue("email")
	order.Phone = r.FormValue("phone")
	order.ProductID = r.FormValue("product_id")

	bytes, _ := json.Marshal(order)

	fmt.Println(string(bytes))

	w.Write([]byte("Processed"))
}

type Product struct {
	UUID    string  `json:"uuid"`
	Product string  `json:"product"`
	Price   float64 `json:"price,string"`
}

type Order struct {
	Name      string `json:"name"`
	Email     string `json:"email"`
	Phone     string `json:"phone"`
	ProductID string `json:"product_id"`
}
