package main

import "fmt"

func main() {
	var name string

	fmt.Println("What is your name?")

	inputs, _ := fmt.Scanf("%q", &name)

	switch inputs {
	case 0:
		fmt.Println("You must enter a name")
	case 1:
		fmt.Printf("Hello %s, Nice to meet you", name)
	}
}
