package main

import (
	"fmt"
	"os"
	"strconv"
)

func main() {
	args := os.Args[1:]

	if len(args) != 2 {
		fmt.Println("You must enter 2 arguments")

		return
	}

	mealTotal, err := strconv.ParseFloat(args[0], 64)

	if err != nil {
		fmt.Println("First argument must be a number")

		return
	}

	tipTotal, err := strconv.ParseFloat(args[1], 64)

	if err != nil {
		fmt.Println("Second argument must be a number")

		return
	}

	total := calculateTotal(mealTotal, tipTotal)

	fmt.Printf("Your meal total will be %.2f", total)
}

func calculateTotal(mealTotal, tipTotal float64) float64 {
	return mealTotal + (mealTotal * (tipTotal / 100))
}
