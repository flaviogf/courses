package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
	"time"
)

func main() {
	begin := time.Now()

	file, err := os.Open("customers.csv")

	if err != nil {
		log.Fatal(err)
	}

	defer file.Close()

	output, err := os.OpenFile("output.csv", os.O_APPEND|os.O_CREATE, 0666)

	if err != nil {
		log.Fatal(err)
	}

	defer output.Close()

	scanner := bufio.NewScanner(file)

	for scanner.Scan() {
		row := strings.Split(scanner.Text(), ",")

		name := row[0]

		age := row[1]

		text := fmt.Sprintf("Customer\nName: %s\nAge: %s\n\n", strings.Title(name), age)

		output.Write([]byte(text))
	}

	elapsed := time.Since(begin)

	fmt.Printf("Has been passed %d nanoseconds\n", elapsed.Nanoseconds())
}
