package controllers

import (
	"html/template"
	"log"
	"net/http"

	"github.com/flaviogf/webapp/models"
	"github.com/flaviogf/webapp/viewmodels"
)

type ShopController struct {
	t *template.Template
}

func NewShopController(t *template.Template) *ShopController {
	return &ShopController{t}
}

func (s *ShopController) Get(w http.ResponseWriter, r *http.Request) {
	categories, err := models.GetCategories()

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		log.Println(err)

		return
	}

	w.Header().Add("Content-Type", "text/html")

	s.t.ExecuteTemplate(w, "shop.html", viewmodels.NewShopViewModel(categories))
}
