package main

import (
	"bytes"
	"context"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net"
	"net/http"
	"os"
	"os/signal"
	"syscall"
	"time"

	"github.com/gorilla/mux"
	"go.opentelemetry.io/contrib/instrumentation/github.com/gorilla/mux/otelmux"
	"go.opentelemetry.io/otel"
	stdout "go.opentelemetry.io/otel/exporters/stdout/stdouttrace"
	"go.opentelemetry.io/otel/propagation"
	"go.opentelemetry.io/otel/sdk/resource"
	sdktrace "go.opentelemetry.io/otel/sdk/trace"
	semconv "go.opentelemetry.io/otel/semconv/v1.4.0"
)

type Person struct {
	Name  string
	Quote string
}

func main() {
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	initTracer()

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	r := mux.NewRouter()

	r.Use(otelmux.Middleware("say-hello"))

	r.Handle("/{name}", &SayHelloHandler{}).Methods(http.MethodGet)

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

	s.Shutdown(ctx)

	log.Println("Server finished")
}

func initTracer() {
	exporter, err := stdout.New(stdout.WithPrettyPrint())

	if err != nil {
		log.Fatal(err)
	}

	tp := sdktrace.NewTracerProvider(
		sdktrace.WithSampler(sdktrace.AlwaysSample()),
		sdktrace.WithBatcher(exporter),
		sdktrace.WithResource(resource.NewWithAttributes(semconv.SchemaURL, semconv.ServiceNameKey.String("say-hello"))),
	)

	otel.SetTracerProvider(tp)
	otel.SetTextMapPropagator(propagation.NewCompositeTextMapPropagator(propagation.TraceContext{}, propagation.Baggage{}))
}

type SayHelloHandler struct{}

func (s *SayHelloHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	vars := mux.Vars(r)

	person, err := getPerson(ctx, vars["name"])

	if err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	message, err := format(person)

	if err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	fmt.Fprintln(w, message)
}

func getPerson(ctx context.Context, name string) (*Person, error) {
	url := "http://big_brother/people/" + name

	req, err := http.NewRequest(http.MethodGet, url, nil)

	if err != nil {
		return nil, err
	}

	req = req.WithContext(ctx)

	otel.GetTextMapPropagator().Inject(ctx, propagation.HeaderCarrier(req.Header))

	client := http.Client{Timeout: 5 * time.Second}

	resp, err := client.Do(req)

	if err != nil {
		return nil, err
	}

	defer resp.Body.Close()

	var person Person

	switch resp.StatusCode {
	case 200:
		json.NewDecoder(resp.Body).Decode(&person)
	default:
		person.Name = name
		person.Quote = "What's up!"
	}

	return &person, nil
}

func format(person *Person) (string, error) {
	buffer := &bytes.Buffer{}

	if err := json.NewEncoder(buffer).Encode(person); err != nil {
		return "", err
	}

	url := "http://formatter"
	resp, err := http.Post(url, "application/json", buffer)

	if err != nil {
		return "", err
	}

	defer resp.Body.Close()

	bytes, err := ioutil.ReadAll(resp.Body)

	if err != nil {
		return "", err
	}

	return string(bytes), nil
}
