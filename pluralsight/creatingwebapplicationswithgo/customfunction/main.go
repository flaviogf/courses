package main

import (
	"log"
	"os"
	"text/template"
)

const tax = 6.75 / 100

const templateString = `
{{- "Information Item"}}
Name: {{.Name}}
Price: {{printf "%.2f" .Price}}
Price with tax: {{.Price | withTax | printf "%.2f"}}
`

type Product struct {
	Name  string
	Price float32
}

func main() {
	logger := log.New(os.Stdout, "INFO: ", log.LstdFlags|log.Lshortfile)

	funcs := template.FuncMap{"withTax": withTax}

	t := template.Must(template.New("template").Funcs(funcs).Parse(templateString))

	product := Product{"God of War Collection", 133.99}

	logger.Println(product)

	err := t.Execute(os.Stdout, product)

	if err != nil {
		logger.Fatalf("Something went wrong: %s", err.Error())
	}
}

func withTax(price float32) float32 {
	return price + (price * tax)
}
