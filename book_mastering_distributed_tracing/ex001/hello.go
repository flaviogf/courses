package main

import (
	"fmt"
	"io"
	"log"
)

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
		log.Fatal(err)
	}

	fmt.Fprintf(w, "Hello, %s! %s", person.Name, person.Quote)

	return nil
}
