package main

func Sum(values [5]int) int {
	sum := 0

	for _, value := range values {
		sum += value
	}

	return sum
}
