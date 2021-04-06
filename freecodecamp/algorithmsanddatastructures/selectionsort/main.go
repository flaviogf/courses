package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

func main() {
	if len(os.Args) < 2 {
		fmt.Println("filename must be informed")
		return
	}

	numbers := loadNumbers(os.Args[1])

	fmt.Println(numbers)

	numbers = selectionSort(numbers)

	fmt.Println(numbers)
}

func loadNumbers(fileName string) []int {
	values := []int{}

	f, err := os.Open(fileName)

	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	s := bufio.NewScanner(f)

	for s.Scan() {
		value, err := strconv.Atoi(s.Text())

		if err != nil {
			log.Fatal(err)
		}

		values = append(values, value)
	}

	return values
}

func selectionSort(values []int) []int {
	sortedList := []int{}

	for len(values) > 0 {
		indexToMove := indexOfMin(values)

		min := values[indexToMove]

		values = removeAt(values, indexToMove)

		sortedList = append(sortedList, min)
	}

	return sortedList
}

func indexOfMin(values []int) int {
	minIndex := 0

	for i := range values {
		if values[i] < values[minIndex] {
			minIndex = i
		}
	}

	return minIndex
}

func removeAt(values []int, index int) []int {
	return append(values[:index], values[index+1:]...)
}
