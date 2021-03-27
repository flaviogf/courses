package main

import "fmt"

func main() {
	numbers := []int{3, 5, 6, 7, 9, 10, 13, 14, 18, 20, 24, 32, 69}

	target := 20

	result := binarySearch(numbers, 0, len(numbers)-1, target)

	fmt.Println(result)
}

func binarySearch(arr []int, left, right, target int) int {
	if right >= left {
		middle := (left + right) / 2

		if arr[middle] == target {
			return middle
		}

		if arr[middle] > target {
			return binarySearch(arr, left, middle-1, target)
		}

		return binarySearch(arr, middle+1, right, target)
	}

	return -1
}
