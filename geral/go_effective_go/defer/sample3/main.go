package main

import "fmt"

func main() {
	a()
}

func a() {
	defer un(trace("a"))
	fmt.Println("in a")
}

func trace(s string) string {
	fmt.Println("entering:", s)
	return s
}

func un(s string) {
	fmt.Println("leaving:", s)
}
