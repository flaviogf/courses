package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func main() {
	file, err := os.Open("log.txt")

	if err != nil {
		log.Fatal(err)
	}

	defer file.Close()

	reader := bufio.NewReader(file)

	for {
		row, err := reader.ReadString('\n')

		if err != nil {
			break
		}

		if strings.Contains(row, "ERROR") {
			fmt.Print(row)
		}
	}
}
