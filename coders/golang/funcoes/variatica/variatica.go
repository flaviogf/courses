package main

import "fmt"

func main() {
	fmt.Printf("Média: %.2f\n", media(7.1, 8.1, 5.9, 9.9))
}

func media(notas ...float64) float64 {
	total := 0.0

	for _, nota := range notas {
		total += nota
	}

	return total / float64(len(notas))
}
