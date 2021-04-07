package main

import (
	"fmt"
	"os"

	"github.com/flaviogf/algorithmsanddatastructures/load"
)

func main() {
	values := load.Values(os.Args[1])

	fmt.Println(values)

	values = mergeSort(values)

	fmt.Println(values)
}

func mergeSort(values []int) []int {
	if len(values) <= 1 {
		return values
	}

	midpoint := len(values) / 2

	leftHalf, rightHalf := values[:midpoint], values[midpoint:]

	leftHalf = mergeSort(leftHalf)

	rightHalf = mergeSort(rightHalf)

	sortedList := []int{}

	i := 0

	j := 0

	for i < len(leftHalf) && j < len(rightHalf) {
		if leftHalf[i] < rightHalf[j] {
			sortedList = append(sortedList, leftHalf[i])
			i++
		} else {
			sortedList = append(sortedList, rightHalf[j])
			j++
		}
	}

	sortedList = append(sortedList, leftHalf[i:]...)

	sortedList = append(sortedList, rightHalf[j:]...)

	return sortedList
}
