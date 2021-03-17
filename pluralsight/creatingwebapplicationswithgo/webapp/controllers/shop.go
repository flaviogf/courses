package controllers

import (
	"encoding/json"
	"html/template"
	"io/ioutil"
	"log"
	"net/http"
	"os"

	"github.com/flaviogf/webapp/viewmodels"
)

type ShopController struct {
	t *template.Template
}

func NewShopController(t *template.Template) *ShopController {
	return &ShopController{t}
}

func (s ShopController) Get(wr http.ResponseWriter, r *http.Request) {
	file, err := os.Open("categories.json")

	if err != nil {
		wr.WriteHeader(http.StatusInternalServerError)

		log.Println(err)

		return
	}

	var categories []viewmodels.CategoryViewModel

	bytes, err := ioutil.ReadAll(file)

	if err != nil {
		wr.WriteHeader(http.StatusInternalServerError)

		log.Println(err)

		return
	}

	json.Unmarshal(bytes, &categories)

	s.t.ExecuteTemplate(wr, "shop.html", viewmodels.NewShopViewModel(categories))
}
