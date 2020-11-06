package main

import "fmt"

func main() {
	x, y := trocar(2, 3)
	fmt.Println(x, y)

	segundo, primeiro := trocar(7, 1)
	fmt.Println(segundo, primeiro)
}

func trocar(p1, p2 int) (segundo, primeiro int) {
	segundo, primeiro = p2, p1
	return
}
