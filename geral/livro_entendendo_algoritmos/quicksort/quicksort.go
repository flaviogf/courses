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

	quicksort(values, 0, len(values)-1)

	fmt.Println(values)
}

func load() []int {
	file, err := os.Open("unsorted.txt")

	if err != nil {
		log.Fatal(err)
	}

	defer file.Close()

	scanner := bufio.NewScanner(file)

	var values []int

	for scanner.Scan() {
		value, _ := strconv.Atoi(scanner.Text())

		values = append(values, value)
	}

	return values
}

func quicksort(values []int, left, right int) {
	if left >= right {
		return
	}

	pivot := values[(left+right)/2]

	index := partition(values, left, right, pivot)

	quicksort(values, left, index-1)

	quicksort(values, index, right)
}

func partition(values []int, left, right, pivot int) int {
	for left <= right {
		for values[left] < pivot {
			left++
		}

		for values[right] > pivot {
			right--
		}

		if left <= right {
			swap(values, left, right)
			left++
			right--
		}
	}

	return left
}

func swap(values []int, i, j int) {
	values[i], values[j] = values[j], values[i]
}
