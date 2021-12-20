package main

import "fmt"

func main() {
	fmt.Println(Sum([]int{1, 2, 3, 4, 5, 6, 7, 8, 9, 10}))
}

func Sum(values []int) int {
	sum := 0

	for _, value := range values {
		sum += value
	}

	return sum
}
