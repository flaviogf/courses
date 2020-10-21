package controllers

import (
	"html/template"
	"log"
	"net/http"
	"strconv"

	"github.com/flaviogf/go_fundamentos_aplicacao_web/models"
)

var t = template.Must(template.ParseGlob("templates/*.html"))

func Index(wr http.ResponseWriter, r *http.Request) {
	products := models.Find()

	t.ExecuteTemplate(wr, "Index", products)
}

func New(wr http.ResponseWriter, r *http.Request) {
	t.ExecuteTemplate(wr, "New", nil)
}

func Insert(wr http.ResponseWriter, r *http.Request) {
	name := r.FormValue("name")
	description := r.FormValue("description")
	priceString := r.FormValue("price")
	quantityString := r.FormValue("quantity")

	price, err := strconv.ParseFloat(priceString, 64)

	if err != nil {
		log.Fatal(err)
	}

	quantity, err := strconv.Atoi(quantityString)

	if err != nil {
		log.Fatal(err)
	}

	models.Create(name, description, price, quantity)

	http.Redirect(wr, r, "/", 301)
}
