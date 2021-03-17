package routes

import (
	"net/http"

	"github.com/flaviogf/webapp/controllers"
)

func RegisterRoutes(indexController controllers.IndexController, shopController controllers.ShopController, categoryController controllers.CategoryController) {
	http.HandleFunc("/", indexController.Get)
	http.HandleFunc("/home", indexController.Get)
	http.HandleFunc("/shop", shopController.Get)
	http.HandleFunc("/category/", categoryController.Get)
}
