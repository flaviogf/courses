package main

import (
	"encoding/json"
	"html/template"
	"io/ioutil"
	"log"
	"net/http"
	"os"

	"github.com/flaviogf/webapp/viewmodel"
)

func main() {
	t := template.Must(template.New("templates").ParseGlob("templates/*.html"))

	http.HandleFunc("/", func(wr http.ResponseWriter, r *http.Request) {
		t.ExecuteTemplate(wr, "index.html", viewmodel.NewIndexViewModel())
	})

	http.HandleFunc("/shop", func(wr http.ResponseWriter, r *http.Request) {
		file, err := os.Open("categories.json")

		if err != nil {
			wr.WriteHeader(http.StatusInternalServerError)

			log.Println(err)

			return
		}

		var categories []viewmodel.CategoryViewModel

		bytes, err := ioutil.ReadAll(file)

		if err != nil {
			wr.WriteHeader(http.StatusInternalServerError)

			log.Println(err)

			return
		}

		json.Unmarshal(bytes, &categories)

		t.ExecuteTemplate(wr, "shop.html", viewmodel.NewShopViewModel(categories))
	})

	http.ListenAndServe(":8080", nil)
}
