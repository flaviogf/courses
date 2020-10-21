package routes

import (
	"net/http"

	"github.com/flaviogf/go_fundamentos_aplicacao_web/controllers"
)

func Configure() {
	http.HandleFunc("/", controllers.Index)
	http.HandleFunc("/new", controllers.New)
	http.HandleFunc("/insert", controllers.Insert)
}
