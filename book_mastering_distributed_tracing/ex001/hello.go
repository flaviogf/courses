package main

import (
	"errors"
	"fmt"
	"io"
)

var PersonDoesNotFoundErr = errors.New("person does not found")

type PersonRepository interface {
	GetPerson(string) (*Person, error)
}

type Person struct {
	Name  string
	Quote string
}

func main() {
	fmt.Println("It works")
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
