package controllers

import (
	"fmt"
	"html/template"
	"net/http"

	"github.com/flaviogf/webapp/viewmodels"
)

type NewsletterController struct {
	t *template.Template
}

func NewNewsletterController(t *template.Template) *NewsletterController {
	return &NewsletterController{t}
}

func (n *NewsletterController) Get(wr http.ResponseWriter, r *http.Request) {
	n.t.ExecuteTemplate(wr, "newsletter.html", viewmodels.NewNewsletterViewModel())
}

func (n *NewsletterController) Post(wr http.ResponseWriter, r *http.Request) {
	fmt.Println(r.Form)

	fmt.Println(r.FormValue("email"))

	fmt.Println(r.Form)

	http.Redirect(wr, r, "/", http.StatusTemporaryRedirect)
}
