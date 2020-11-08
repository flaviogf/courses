package main

import (
	"fmt"
	"time"
)

func main() {
	go fale("Maria", "Entendi!!!", 10)
	fale("João", "Parabens", 5)
}

func fale(pessoa, texto string, quantidade int) {
	for i := 0; i < quantidade; i++ {
		time.Sleep(time.Second)
		fmt.Printf("%s: %s (iteração %d)\n", pessoa, texto, i)
	}
}
