package controllers

import (
	"html/template"
	"net/http"
	"time"

	"github.com/flaviogf/webapp/viewmodels"
)

type IndexController struct {
	t *template.Template
}

func NewIndexController(t *template.Template) *IndexController {
	return &IndexController{t}
}

func (i *IndexController) Get(w http.ResponseWriter, r *http.Request) {
	time.Sleep(4 * time.Second)

	w.Header().Add("Content-Type", "text/html")

	i.t.ExecuteTemplate(w, "index.html", viewmodels.NewIndexViewModel())
}
