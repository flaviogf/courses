package main

import (
	"fmt"
	"os"

	"github.com/flaviogf/algorithmsanddatastructures/load"
)

func main() {
	values := load.Values(os.Args[1])

	fmt.Println(values)

	values = selectionSort(values)

	fmt.Println(values)
}

func selectionSort(values []int) []int {
	for i := 0; i < len(values)-1; i++ {
		for j := i + 1; j < len(values); j++ {
			if values[j] < values[i] {
				values[j], values[i] = values[i], values[j]
			}
		}
	}

	return values
}
