package main

import "fmt"

func main() {
	ourString := "\x47\x6f"

	fmt.Printf("%q\n", ourString)

	for _, it := range ourString {
		fmt.Printf("%q\n", it)
	}
}
