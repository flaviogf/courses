package main

import "fmt"

func main() {
	values := []int{1, 3, 5, 7, 9}

	fmt.Println(binarySearch(values, 7))
}

func binarySearch(values []int, target int) bool {
	left := 0

	right := len(values) - 1

	for left <= right {
		mid := (left + right) / 2

		if values[mid] == target {
			return true
		} else if values[mid] > target {
			right = mid - 1
		} else {
			left = mid + 1
		}
	}

	return false
}
