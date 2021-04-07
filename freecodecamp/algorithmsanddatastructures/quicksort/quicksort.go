package main

import (
	"fmt"
	"os"

	"github.com/flaviogf/algorithmsanddatastructures/load"
)

func main() {
	values := load.Values(os.Args[1])

	fmt.Println(values)

	values = quickSort(values)

	fmt.Println(values)
}

func quickSort(values []int) []int {
	if len(values) <= 1 {
		return values
	}

	leftHalf := []int{}

	rightHalf := []int{}

	pivot := values[0]

	for i := 1; i < len(values); i++ {
		if values[i] < pivot {
			leftHalf = append(leftHalf, values[i])
		} else {
			rightHalf = append(rightHalf, values[i])
		}
	}

	sortedList := []int{}

	sortedList = append(sortedList, quickSort(leftHalf)...)

	sortedList = append(sortedList, pivot)

	sortedList = append(sortedList, quickSort(rightHalf)...)

	return sortedList
}
