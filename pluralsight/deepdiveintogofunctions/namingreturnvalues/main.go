package main

import (
	"errors"
	"fmt"
)

func main() {
	x := 6.0

	y := 3.0

	result, err := divide(x, y)

	if err != nil {
		fmt.Printf("something went wrong: %s", err.Error())
	} else {
		fmt.Printf("%f divided by %f is %f", x, y, result)
	}
}

func divide(x, y float64) (result float64, err error) {
	if y == 0 {
		err = errors.New("cannot divide by zero")
	}

	result = x / y

	return
}
