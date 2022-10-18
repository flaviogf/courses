package main

import "fmt"

func main() {
	a()
}

func a() {
	trace("a")
	defer untrace("a")
	// do something
}

func trace(s string) {
	fmt.Printf("entering: %s\n", s)
}

func untrace(s string) {
	fmt.Printf("leaving: %s\n", s)
}
