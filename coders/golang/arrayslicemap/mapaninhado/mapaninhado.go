package main

import "fmt"

func main() {
	funcionariosPorLetra := map[string]map[string]float64{
		"G": {
			"Gabriela Silva": 15456.78,
			"Guga Pereira":   8456.78,
		},
		"J": {
			"José João": 11325.45,
		},
		"P": {
			"Pedro Junior": 1200.00,
		},
	}

	for letra, funcionarios := range funcionariosPorLetra {
		fmt.Println(letra, funcionarios)
	}
}
