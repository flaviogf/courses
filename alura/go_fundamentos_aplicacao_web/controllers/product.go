package controllers

import (
	"html/template"
	"log"
	"net/http"
	"strconv"
	"strings"

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

func Delete(wr http.ResponseWriter, r *http.Request) {
	idString := strings.TrimPrefix(r.URL.Path, "/delete/")

	id, err := strconv.Atoi(idString)

	if err != nil {
		log.Fatal(err)
	}

	models.Delete(id)

	http.Redirect(wr, r, "/", 301)
}

func Edit(wr http.ResponseWriter, r *http.Request) {
	idString := strings.TrimPrefix(r.URL.Path, "/edit/")

	id, err := strconv.Atoi(idString)

	if err != nil {
		log.Fatal(err)
	}

	product := models.FindOne(id)

	t.ExecuteTemplate(wr, "Edit", product)
}
