package main

import "fmt"

type imprimivel interface {
	toString() string
}

type pessoa struct {
	nome      string
	sobrenome string
}

func (p pessoa) toString() string {
	return fmt.Sprintf("%s %s", p.nome, p.sobrenome)
}

type produto struct {
	nome  string
	preco float64
}

func (p produto) toString() string {
	return fmt.Sprintf("%s %.2f", p.nome, p.preco)
}

func main() {
	var coisa imprimivel = pessoa{"Roberto", "Silva"}
	fmt.Println(coisa.toString())
	imprimir(coisa)

	coisa = produto{"Calça Jeans", 79.90}
	fmt.Println(coisa.toString())
	imprimir(coisa)

	p2 := produto{"Calça Jeans", 179.90}
	imprimir(p2)
}

func imprimir(x imprimivel) {
	fmt.Println(x.toString())
}
