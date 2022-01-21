package main

import (
	"fmt"
	"log"
	"os"
)

func main() {
	if len(os.Args[1:]) == 0 {
		log.Fatalln("you must specify a name")
	}

	sayHello(os.Args[1])
}

func sayHello(name string) {
	fmt.Printf("Hello, %s\n", name)
}
