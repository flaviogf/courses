package main

import "fmt"

func main() {
	var name *string = new(string)

	*name = "Frank"

	fmt.Println(name, *name)

	firstName := "Frank"

	ptr := &firstName

	fmt.Println(ptr, *ptr)

	firstName = "Flavio"

	fmt.Println(ptr, *ptr)

	x := 5
	fmt.Println(x)
	zero(&x)
	fmt.Println(x)
}

func zero(xPtr *int) {
	*xPtr = 0
}
