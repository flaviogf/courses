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
)

func main() {
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	l, err := net.Listen("tcp", "0.0.0.0:80")

	if err != nil {
		log.Fatal(err)
	}

	r := mux.NewRouter()

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

type Person struct {
	Name  string
	Quote string
}

type SayHelloHandler struct{}

func (s *SayHelloHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	person, err := getPerson(vars["name"])

	if err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	buffer := &bytes.Buffer{}

	if err := json.NewEncoder(buffer).Encode(person); err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	url := "http://formatter"
	resp, err := http.Post(url, "application/json", buffer)

	if err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	defer resp.Body.Close()

	bytes, err := ioutil.ReadAll(resp.Body)

	if err != nil {
		http.Error(w, "Something went wrong", http.StatusInternalServerError)
		return
	}

	fmt.Fprintln(w, string(bytes))
}

func getPerson(name string) (*Person, error) {
	url := "http://big_brother/people/" + name
	resp, err := http.Get(url)

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
