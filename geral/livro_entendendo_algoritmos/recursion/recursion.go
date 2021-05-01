package main

import "fmt"

func main() {
	fmt.Println(factorial(6))

	fmt.Println(fibonacci(6))
}

func factorial(n int) int {
	if n >= 2 {
		return n * factorial(n-1)
	}

	return 1
}

func fibonacci(n int) int {
	if n >= 3 {
		return fibonacci(n-1) + fibonacci(n-2)
	}

	return 1
}
