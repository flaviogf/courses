package main

import (
	"html/template"
	"net/http"

	"github.com/flaviogf/webapp/controllers"
	"github.com/flaviogf/webapp/routes"
)

func main() {
	t := template.Must(template.New("templates").ParseGlob("templates/*.html"))

	indexController := controllers.NewIndexController(t)

	shopController := controllers.NewShopController(t)

	routes.RegisterRoutes(indexController, shopController)

	http.ListenAndServe(":8080", nil)
}
