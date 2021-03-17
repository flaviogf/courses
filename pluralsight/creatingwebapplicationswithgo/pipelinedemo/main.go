package main

import (
	"log"
	"os"
	"text/template"
)

const tax = 6.75 / 100

type Product struct {
	Name  string
	Price float32
}

func (p Product) PriceWithTax() float32 {
	return p.Price + (p.Price * tax)
}

const templateString = `
{{- "Information Item"}}
Name: {{.Name}}
Price: {{.Price}}
Price with tax: {{printf "%.2f" .PriceWithTax}}
Price with Tax: {{.PriceWithTax | printf "%.2f"}}
`

func main() {
	logger := log.New(os.Stdout, "ERROR: ", log.LstdFlags)

	t := template.Must(template.New("template").Parse(templateString))

	product := Product{
		Name:  "God of War Collection (PS3)",
		Price: 133.99,
	}

	err := t.Execute(os.Stdout, product)

	if err != nil {
		logger.Println(err)
	}
}
