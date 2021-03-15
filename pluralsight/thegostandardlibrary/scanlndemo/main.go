package main

import (
	"fmt"
)

func main() {
	fmt.Println("What numbers would you like to add?")
	var x int
	var y int
	fmt.Scanln(&x, &y)
	fmt.Printf("Result: %d\n", x+y)
}
