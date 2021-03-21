package main

import (
	"fmt"
	"strings"
)

func main() {
	string1 := "this is a string"

	string2 := "this is a string"

	if strings.Compare(string1, string2) == 0 {
		fmt.Println("These strings are identical")
	} else {
		fmt.Println("These strings don't match")
	}
}
