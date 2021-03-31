package main

import "fmt"

func main() {
	fmt.Printf("Sum of numbers are: %d", sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
}

func sum(numbers ...int64) int64 {
	var result int64 = 0

	for _, number := range numbers {
		result += number
	}

	return result
}
