package main

import (
	"log"
	"os"
	"text/template"
)

type TemplateData struct {
	FirstName string
	LastName  string
	Age       int
}

func main() {
	t, err := template.New("template").Parse("My first name is {{.FirstName}}, my last name is {{.LastName}}, I am {{.Age}} years old")

	if err != nil {
		log.Fatal(err)
	}

	templateData := TemplateData{"Flavio", "Fernandes", 24}

	t.Execute(os.Stdout, templateData)
}
