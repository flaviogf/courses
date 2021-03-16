package main

import "fmt"

func main() {
	name := "Frank"

	age := 3

	fmt.Printf("My dog's name is %s he is %d years old\n", name, age)

	fmt.Printf("|%7.2f|%7.2f|%7.2f|%7.2f|\n", 100.50, 20.0, 30.50, 40.0)
	fmt.Printf("|%7.2f|%7.2f|%7.2f|%7.2f|\n", 10.50, 200.0, 30.50, 40.0)

	fmt.Printf("|%-7.2f|%-7.2f|%-7.2f|%-7.2f|\n", 10.50, 20.0, 30.50, 400.0)
	fmt.Printf("|%-7.2f|%-7.2f|%-7.2f|%-7.2f|\n", 10.50, 20.0, 300.50, 40.0)
}
