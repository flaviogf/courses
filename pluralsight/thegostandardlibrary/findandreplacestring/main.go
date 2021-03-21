package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func main() {
	if len(os.Args) < 2 {
		fmt.Println("You must specify a log level")

		return
	}

	logLevel := os.Args[1]

	file, err := os.Open("logs.txt")

	if err != nil {
		log.Fatal(err)
	}

	scanner := bufio.NewScanner(file)

	for scanner.Scan() {
		text := scanner.Text()

		if strings.HasPrefix(text, logLevel) {
			fmt.Println(text)
		}
	}
}

func CreateLog() {
	output, _ := os.OpenFile("logs.txt", os.O_APPEND|os.O_CREATE, 0666)

	defer output.Close()

	logInfo := log.New(output, "INFO: ", log.LstdFlags)

	logWarning := log.New(output, "WARNING: ", log.LstdFlags)

	logError := log.New(output, "ERROR: ", log.LstdFlags)

	logInfo.Println("this is an info message")

	logWarning.Println("this is a waning message")

	logError.Println("this is an error message")
}
