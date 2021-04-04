package main

import "fmt"

func main() {
	numbers := []int64{100, 89, 150, 75, 64, 230, 20, 15}

	numbers = mergeSort(numbers)

	fmt.Println(numbers)
}

func mergeSort(numbers []int64) []int64 {
	if len(numbers) <= 1 {
		return numbers
	}

	left, right := split(numbers)

	left = mergeSort(left)

	right = mergeSort(right)

	return merge(left, right)
}

func split(numbers []int64) (left []int64, right []int64) {
	midpoint := len(numbers) / 2

	left = numbers[:midpoint]

	right = numbers[midpoint:]

	return
}

func merge(left, right []int64) []int64 {
	numbers := []int64{}
	i := 0
	j := 0

	for i < len(left) && j < len(right) {
		if left[i] < right[j] {
			numbers = append(numbers, left[i])
			i++
		} else {
			numbers = append(numbers, right[j])
			j++
		}
	}

	for i < len(left) {
		numbers = append(numbers, left[i])
		i++
	}

	for j < len(right) {
		numbers = append(numbers, right[j])
		j++
	}

	return numbers
}
