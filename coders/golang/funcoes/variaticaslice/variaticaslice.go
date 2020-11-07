package main

import "fmt"

func main() {
	aprovados := []string{"Maria", "Pedro", "Rafael", "Guilherme"}
	imprimirAprovados(aprovados...)
}

func imprimirAprovados(aprovados ...string) {
	for i, aprovado := range aprovados {
		fmt.Printf("%d) %s\n", i, aprovado)
	}
}
