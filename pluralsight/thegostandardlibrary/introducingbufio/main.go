package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		if text := scanner.Text(); text == "/quit" {
			os.Exit(3)
		} else {
			fmt.Printf("You typed %s\n", text)
		}
	}

	if err := scanner.Err(); err != nil {
		fmt.Println(err)
	}
}
