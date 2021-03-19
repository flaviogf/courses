package main

import (
	"database/sql"
	"html/template"
	"log"
	"net/http"

	_ "github.com/lib/pq"

	"github.com/flaviogf/webapp/controllers"
	"github.com/flaviogf/webapp/middlewares"
	"github.com/flaviogf/webapp/models"
	"github.com/flaviogf/webapp/routes"
)

func main() {
	conninfo := "user=postgres password=postgres dbname=webapp sslmode=disable"

	db, err := sql.Open("postgres", conninfo)

	if err != nil {
		log.Fatalf("unable to connect to database %v\n", err)
	}

	models.SetDBInstance(db)

	t := template.Must(template.New("templates").ParseGlob("templates/*.html"))

	indexController := controllers.NewIndexController(t)

	shopController := controllers.NewShopController(t)

	categoryController := controllers.NewCategoryController(t)

	newsletterController := controllers.NewNewsletterController(t)

	routes.RegisterRoutes(indexController, shopController, categoryController, newsletterController)

	http.ListenAndServeTLS(":8080", "cert.pem", "key.pem", middlewares.NewTimeoutMiddleware(middlewares.NewGzipMiddleware(http.DefaultServeMux)))
}
