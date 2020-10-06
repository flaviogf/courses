package main

import (
	"fmt"
	"reflect"
)

func main() {
	// var name string = "Frank"
	// var age int = 2
	// var version float32 = 1.1

	// var name = "Frank"
	// var age = 2
	// var version = 1.1

	name := "Frank"
	age := 2
	version := 1.1

	fmt.Println("My name is ", name)
	fmt.Println("I'm ", age)
	fmt.Println("Hello World!")
	fmt.Println("My first application in Go! Version: ", version)
	fmt.Println("The typo of version variable is: ", reflect.TypeOf(version))
}
