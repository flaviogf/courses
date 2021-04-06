package main

import (
	"bufio"
	"fmt"
	"log"
	"math/rand"
	"os"
	"strconv"
	"time"
)

func main() {
	if len(os.Args) < 2 {
		fmt.Println("filename must be informed")

		return
	}

	rand.Seed(time.Now().UTC().UnixNano())

	numbers := loadNumbers()

	fmt.Println(numbers)

	numbers = bogoSort(numbers)

	fmt.Println(numbers)
}

func loadNumbers() []int {
	f, err := os.Open(os.Args[1])

	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	numbers := []int{}

	s := bufio.NewScanner(f)

	for s.Scan() {
		n, err := strconv.Atoi(s.Text())

		if err != nil {
			log.Fatal(err)
		}

		numbers = append(numbers, n)
	}

	return numbers
}

func bogoSort(arr []int) []int {
	for !isSorted(arr) {
		rand.Shuffle(len(arr), func(i, j int) {
			arr[i], arr[j] = arr[j], arr[i]
		})
	}

	return arr
}

func isSorted(arr []int) bool {
	for i := 0; i < len(arr)-1; i++ {
		if arr[i] > arr[i+1] {
			return false
		}
	}

	return true
}
