package controllers

import (
	"html/template"
	"net/http"
	"regexp"
	"strconv"

	"github.com/flaviogf/webapp/models"
	"github.com/flaviogf/webapp/viewmodels"
)

type CategoryController struct {
	t *template.Template
}

func NewCategoryController(t *template.Template) *CategoryController {
	return &CategoryController{t}
}

func (c *CategoryController) Get(w http.ResponseWriter, r *http.Request) {
	regex, _ := regexp.Compile(`/category/(\d+)`)

	matches := regex.FindStringSubmatch(r.URL.Path)

	if len(matches) <= 0 {
		w.WriteHeader(http.StatusNotFound)

		return
	}

	id, _ := strconv.Atoi(matches[1])

	category, err := models.GetCategory(id)

	if err != nil {
		w.WriteHeader(http.StatusNotFound)

		return
	}

	w.Header().Add("Content-Type", "text/html")

	c.t.ExecuteTemplate(w, "category.html", viewmodels.NewCategoryViewModel(category))
}
