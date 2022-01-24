package main

import (
	"errors"
	"fmt"
	"io"
	"net/http"

	"github.com/gorilla/mux"
)

var PersonDoesNotFoundErr = errors.New("person does not found")

type PostgresPersonRepository struct{}

func (r *PostgresPersonRepository) GetPerson(name string) (*Person, error) {
	return nil, nil
}

type PersonRepository interface {
	GetPerson(string) (*Person, error)
}

type Person struct {
	Name  string
	Quote string
}

func main() {
}

func sayHelloHandler(repository PersonRepository) func(http.ResponseWriter, *http.Request) {
	return func(w http.ResponseWriter, r *http.Request) {
		vars := mux.Vars(r)

		err := SayHello(w, repository, vars["name"])

		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
		}
	}
}

func SayHello(w io.Writer, r PersonRepository, name string) error {
	person, err := r.GetPerson(name)

	if err != nil {
		return err
	}

	if person == nil {
		fmt.Fprintf(w, "Hello, %s!", name)
		return nil
	}

	fmt.Fprintf(w, "Hello, %s! %s", person.Name, person.Quote)

	return nil
}
