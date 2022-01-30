package main

import (
	"database/sql"
	"fmt"
	"log"
	"net"
	"net/http"
	"os"
	"time"

	"github.com/gorilla/mux"
	_ "github.com/lib/pq"
)

func main() {
	db, err := sql.Open(os.Getenv("DB_DRIVER"), os.Getenv("DB_DATASOURCE"))

	if err != nil {
		log.Fatal(err)
	}

	err = db.Ping()

	if err != nil {
		log.Fatal(err)
	}

	r := mux.NewRouter()

	r.HandleFunc("/people/{name}", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprint(w, "It works")
	})

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	s := http.Server{
		Handler:           r,
		IdleTimeout:       time.Minute,
		ReadHeaderTimeout: 5 * time.Second,
	}

	if err := s.Serve(l); err != nil {
		log.Fatal(err)
	}
}
