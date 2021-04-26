package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

func main() {
	values := load()

	result := binarySearch(values, 9773)

	fmt.Println(result)
}

func load() []int {
	file, err := os.Open("sorted.txt")

	if err != nil {
		log.Fatal(err)
	}

	defer file.Close()

	scanner := bufio.NewScanner(file)

	values := make([]int, 0)

	for scanner.Scan() {
		value, _ := strconv.Atoi(scanner.Text())

		values = append(values, value)
	}

	return values
}

func binarySearch(values []int, target int) int {
	left := 0

	right := len(values) - 1

	for left <= right {
		mid := (left + right) / 2

		if values[mid] == target {
			return mid
		} else if values[mid] < target {
			left = mid + 1
		} else {
			right = mid - 1
		}
	}

	return -1
}
