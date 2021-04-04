package main

import "fmt"

func main() {
	numbers := []int{15, 20, 64, 75, 89, 100, 150, 230}

	i := binarySearch(numbers, 0, len(numbers)-1, 230)

	if i != -1 {
		fmt.Printf("Element found at index: %d\n", i)
	} else {
		fmt.Println("Element not found")
	}
}

func binarySearch(arr []int, left, right, target int) int {
	if right >= left {
		midpoint := (left + right) / 2

		if arr[midpoint] == target {
			return midpoint
		}

		if arr[midpoint] > target {
			return binarySearch(arr, left, midpoint-1, target)
		}

		return binarySearch(arr, midpoint+1, right, target)
	}

	return -1
}
