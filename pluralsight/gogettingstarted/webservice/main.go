package main

import (
	"net/http"

	"github.com/flaviogf/webservice/controllers"
)

func main() {
	controllers.RegisterControllers()

	http.ListenAndServe(":3000", nil)
}
