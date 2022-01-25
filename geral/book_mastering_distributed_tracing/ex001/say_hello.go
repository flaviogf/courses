package main

import (
	"context"
	"database/sql"
	"errors"
	"fmt"
	"io"
	"log"
	"net"
	"net/http"
	"os"
	"time"

	"github.com/gorilla/mux"
	"go.opentelemetry.io/contrib/instrumentation/net/http/otelhttp"
	"go.opentelemetry.io/otel"
	"go.opentelemetry.io/otel/exporters/jaeger"
	"go.opentelemetry.io/otel/sdk/resource"
	tracesdk "go.opentelemetry.io/otel/sdk/trace"
	semconv "go.opentelemetry.io/otel/semconv/v1.4.0"

	_ "github.com/lib/pq"
)

var PersonDoesNotFoundErr = errors.New("person does not found")

type PostgresPersonRepository struct {
	db *sql.DB
}

func (r *PostgresPersonRepository) GetPerson(ctx context.Context, name string) (*Person, error) {
	var p Person

	query := "SELECT name, quote FROM people WHERE name=$1"
	err := r.db.QueryRowContext(ctx, query, name).Scan(&p.Name, &p.Quote)

	switch {
	case err == sql.ErrNoRows:
		return nil, PersonDoesNotFoundErr
	case err != nil:
		return nil, err
	default:
		return &p, nil
	}
}

type PersonRepository interface {
	GetPerson(context.Context, string) (*Person, error)
}

type Person struct {
	Name  string
	Quote string
}

func main() {
	db, err := sql.Open(os.Getenv("DB_DRIVER"), os.Getenv("DB_CONNECTION"))

	if err != nil {
		log.Fatal(err)
	}

	err = db.Ping()

	if err != nil {
		log.Fatal(err)
	}

	exp, err := jaeger.New(jaeger.WithCollectorEndpoint(jaeger.WithEndpoint(os.Getenv("JAEGER_ENDPOINT"))))

	if err != nil {
		log.Fatal(err)
	}

	res := resource.NewWithAttributes(
		semconv.SchemaURL,
		semconv.ServiceNameKey.String("sayHello"),
	)

	tp := tracesdk.NewTracerProvider(
		tracesdk.WithBatcher(exp),
		tracesdk.WithResource(res),
	)

	otel.SetTracerProvider(tp)

	r := mux.NewRouter()
	r.Handle("/sayHello/{name}", otelhttp.NewHandler(sayHelloHandler(&PostgresPersonRepository{db}), "sayHello"))

	s := http.Server{
		Handler:           r,
		IdleTimeout:       time.Minute,
		ReadHeaderTimeout: 5 * time.Second,
	}

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	if err := s.Serve(l); err != nil {
		log.Fatal(err)
	}
}

func sayHelloHandler(repository PersonRepository) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		vars := mux.Vars(r)

		err := SayHello(r.Context(), w, repository, vars["name"])

		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
		}
	})
}

func SayHello(ctx context.Context, w io.Writer, r PersonRepository, name string) error {
	person, err := r.GetPerson(ctx, name)

	if errors.Is(err, PersonDoesNotFoundErr) {
		fmt.Fprintf(w, "Hello, %s!", name)
		return nil
	}

	if err != nil {
		return err
	}

	fmt.Fprintf(w, "Hello, %s! %s", person.Name, person.Quote)

	return nil
}
