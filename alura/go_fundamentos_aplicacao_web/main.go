package main

import (
	"net/http"

	"github.com/flaviogf/go_fundamentos_aplicacao_web/routes"

	_ "github.com/lib/pq"
)

func main() {
	routes.Configure()

	http.ListenAndServe(":8000", nil)
}
