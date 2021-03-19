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

func (n *NewsletterController) Get(w http.ResponseWriter, r *http.Request) {
	w.Header().Add("Content-Type", "text/html")

	n.t.ExecuteTemplate(w, "newsletter.html", viewmodels.NewNewsletterViewModel())
}

func (n *NewsletterController) Post(w http.ResponseWriter, r *http.Request) {
	fmt.Println(r.Form)

	fmt.Println(r.FormValue("email"))

	fmt.Println(r.Form)

	http.Redirect(w, r, "/", http.StatusTemporaryRedirect)
}
