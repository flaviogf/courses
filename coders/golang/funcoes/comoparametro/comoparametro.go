package main

import "fmt"

func main() {
	resultado := exec(multiplicacao, 3, 4)

	fmt.Println(resultado)
}

func exec(fn func(int, int) int, x, y int) int {
	return fn(x, y)
}

func multiplicacao(x, y int) int {
	return x * y
}
