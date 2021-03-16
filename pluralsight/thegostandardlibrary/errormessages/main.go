package main

import (
	"bufio"
	"flag"
	"fmt"
	"os"
)

type messageLevel int

const (
	INFO messageLevel = iota
	WARNING
	ERROR
)

func main() {
	showMessage(INFO, "About to open the file")

	fileName := flag.String("file", "test.txt", "Filename you want to read")

	flag.Parse()

	file, err := os.Open(*fileName)

	if err != nil {
		showMessage(ERROR, err.Error())
	}

	defer file.Close()

	scanner := bufio.NewScanner(file)

	for scanner.Scan() {
		fmt.Println(scanner.Text())
	}
}

func showMessage(level messageLevel, message string) {
	funcs := map[messageLevel]func(string){
		INFO: func(s string) {
			fmt.Printf("INFORMATION: %s\n", message)
		},
		WARNING: func(s string) {
			fmt.Printf("WARNING: %s\n", message)
		},
		ERROR: func(s string) {
			fmt.Printf("ERROR: %s\n", message)
			os.Exit(1)
		},
	}

	funcs[level](message)
}
