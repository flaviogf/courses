package routes

import (
	"net/http"

	"github.com/flaviogf/webapp/controllers"
)

func RegisterRoutes(indexController *controllers.IndexController, shopController *controllers.ShopController) {
	http.HandleFunc("/", indexController.Get)
	http.HandleFunc("/home", indexController.Get)
	http.HandleFunc("/shop", shopController.Get)
}
