package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net"
	"net/http"
	"os"
	"os/signal"
	"syscall"
	"time"

	"github.com/gorilla/mux"
)

func main() {
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	r := mux.NewRouter()
	r.Handle("/", &FormatterHandler{}).Methods(http.MethodPost)

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

type Person struct {
	Name  string
	Quote string
}

type FormatterHandler struct{}

func (f *FormatterHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	dec := json.NewDecoder(r.Body)

	defer r.Body.Close()

	var person Person

	if err := dec.Decode(&person); err != nil {
		http.Error(w, "Could not decode the request body", http.StatusInternalServerError)
		return
	}

	fmt.Fprintf(w, "Hello %s! %s", person.Name, person.Quote)
}
