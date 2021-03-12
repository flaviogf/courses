package main

import (
	"bufio"
	"flag"
	"fmt"
	"log"
	"os"
	"strings"
)

func main() {
	path := flag.String("path", "log.txt", "Path of the file that should be read.")

	level := flag.String("level", "ERROR", "Log level to search for. (INFO, WARNING, ERROR)")

	flag.Parse()

	file, err := os.Open(*path)

	if err != nil {
		log.Fatal(err)
	}

	reader := bufio.NewReader(file)

	for {
		line, err := reader.ReadString('\n')

		if err != nil {
			break
		}

		if strings.Contains(line, *level) {
			fmt.Print(line)
		}
	}
}
