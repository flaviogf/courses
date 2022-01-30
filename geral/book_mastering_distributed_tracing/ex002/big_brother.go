package main

import (
	"context"
	"database/sql"
	"encoding/json"
	"errors"
	"log"
	"net"
	"net/http"
	"os"
	"os/signal"
	"syscall"
	"time"

	"github.com/gorilla/mux"
	_ "github.com/lib/pq"
)

func main() {
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	db, err := sql.Open(os.Getenv("DB_DRIVER"), os.Getenv("DB_DATASOURCE"))

	if err != nil {
		log.Fatal(err)
	}

	err = db.Ping()

	if err != nil {
		log.Fatal(err)
	}

	r := mux.NewRouter()

	r.Handle("/people/{name}", &GetPersonHandler{r: &PostgresPersonRepository{db: db}})

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	s := http.Server{
		Handler:           r,
		IdleTimeout:       time.Minute,
		ReadHeaderTimeout: 5 * time.Second,
	}

	go func() {
		if err := s.Serve(l); err != nil {
			log.Println(err)
		}
	}()

	signalCh := make(chan os.Signal, 1)
	signal.Notify(signalCh, syscall.SIGTERM, syscall.SIGINT)
	<-signalCh

	db.Close()
	s.Shutdown(ctx)

	log.Println("Server finished")
}

type Person struct {
	Name  string `json:"name"`
	Quote string `json:"quote"`
}

type GetPersonHandler struct {
	r PersonRepository
}

func (g *GetPersonHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	person, err := g.r.GetPerson(r.Context(), vars["name"])

	switch {
	case errors.Is(err, sql.ErrNoRows):
		http.Error(w, "Not Found", http.StatusNotFound)
	case err != nil:
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
	default:
		enc := json.NewEncoder(w)
		enc.Encode(person)
	}
}

type PostgresPersonRepository struct {
	db *sql.DB
}

func (p *PostgresPersonRepository) GetPerson(ctx context.Context, name string) (*Person, error) {
	stmt := "SELECT name, quote FROM people WHERE name = $1"
	row := p.db.QueryRowContext(ctx, stmt, name)

	var person Person
	err := row.Scan(&person.Name, &person.Quote)

	return &person, err
}

type PersonRepository interface {
	GetPerson(context.Context, string) (*Person, error)
}