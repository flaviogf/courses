package main

import "fmt"

func main() {
	fmt.Println(Hello(""))
	fmt.Println(Hello("Flavio"))
}

func Hello(name string) string {
	if name != "" {
		return "Hello, " + name
	}

	return "Hello, world"
}
