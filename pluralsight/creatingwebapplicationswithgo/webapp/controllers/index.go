package controllers

import (
	"html/template"
	"net/http"

	"github.com/flaviogf/webapp/viewmodels"
)

type IndexController struct {
	t *template.Template
}

func NewIndexController(t *template.Template) IndexController {
	return IndexController{t}
}

func (i IndexController) Get(wr http.ResponseWriter, r *http.Request) {
	i.t.ExecuteTemplate(wr, "index.html", viewmodels.NewIndexViewModel())
}
