package main

import (
	"fmt"
	"math/rand"
	"os"

	"github.com/flaviogf/algorithmsanddatastructures/load"
)

func main() {
	values := load.Values(os.Args[1])

	fmt.Println(values)

	values = bogoSort(values)

	fmt.Println(values)
}

func bogoSort(values []int) []int {
	for !isSorted(values) {
		rand.Shuffle(len(values), func(i, j int) {
			values[i], values[j] = values[j], values[i]
		})
	}

	return values
}

func isSorted(values []int) bool {
	for i := 0; i < len(values)-1; i++ {
		if values[i] > values[i+1] {
			return false
		}
	}

	return true
}
