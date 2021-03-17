package main

import (
	"html/template"
	"net/http"

	"github.com/flaviogf/webapp/viewmodel"
)

func main() {
	t := template.Must(template.New("templates").ParseGlob("templates/*.html"))

	http.HandleFunc("/", func(wr http.ResponseWriter, r *http.Request) {
		t.ExecuteTemplate(wr, "index.html", viewmodel.NewIndexViewModel())
	})

	http.HandleFunc("/shop", func(wr http.ResponseWriter, r *http.Request) {
		t.ExecuteTemplate(wr, "shop.html", nil)
	})

	http.ListenAndServe(":8080", nil)
}
