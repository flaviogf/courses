package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func main() {
	file, err := os.Open("family.txt")

	if err != nil {
		log.Fatal(err)
	}

	scanner := bufio.NewScanner(file)

	for scanner.Scan() {
		var name string
		var age int

		times, _ := fmt.Sscanf(scanner.Text(), "%s is %d years old", &name, &age)

		if times == 2 {
			fmt.Printf("%s,%d\n", name, age)
		}
	}
}
