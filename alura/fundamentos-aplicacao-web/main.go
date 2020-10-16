package main

import (
	"net/http"
	"text/template"
)

var t = template.Must(template.ParseGlob("templates/*.html"))

func main() {
	http.HandleFunc("/", index)

	http.ListenAndServe(":8000", nil)
}

func index(wr http.ResponseWriter, r *http.Request) {
	t.ExecuteTemplate(wr, "Index", nil)
}
