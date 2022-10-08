package main

import (
	"example.com/greetings"
	"fmt"
)

func main() {
	message := greetings.Hello("Gladys")

	fmt.Println(message)
}
