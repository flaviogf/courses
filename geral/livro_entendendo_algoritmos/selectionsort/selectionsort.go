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

	values = selectionSort(values)

	fmt.Println(values)
}

func load() []int {
	file, err := os.Open("unsorted.txt")

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

func selectionSort(values []int) []int {
	sortedList := make([]int, 0)

	for len(values) != 0 {
		lowestValue, lowestIndex := lowest(values)

		sortedList = append(sortedList, lowestValue)

		values = append(values[:lowestIndex], values[lowestIndex+1:]...)
	}

	return sortedList
}

func lowest(values []int) (int, int) {
	lowestValue, lowestIndex := values[0], 0

	for index, value := range values {
		if lowestValue > value {
			lowestValue, lowestIndex = value, index
		}
	}

	return lowestValue, lowestIndex
}
