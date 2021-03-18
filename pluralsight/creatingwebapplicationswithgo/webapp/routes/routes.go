package routes

import (
	"net/http"

	"github.com/flaviogf/webapp/controllers"
)

func RegisterRoutes(
	indexController *controllers.IndexController,
	shopController *controllers.ShopController,
	categoryController *controllers.CategoryController,
	newsletterController *controllers.NewsletterController,
) {
	http.HandleFunc("/", indexController.Get)

	http.HandleFunc("/home", indexController.Get)

	http.HandleFunc("/shop", shopController.Get)

	http.HandleFunc("/category/", categoryController.Get)

	http.HandleFunc("/newsletter", func(wr http.ResponseWriter, r *http.Request) {
		switch r.Method {
		case http.MethodGet:
			newsletterController.Get(wr, r)
		case http.MethodPost:
			newsletterController.Post(wr, r)
		default:
			wr.WriteHeader(http.StatusMethodNotAllowed)
		}
	})
}
