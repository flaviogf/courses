package main

import (
	"errors"
	"fmt"
	"log"
	"math/rand"
	"time"
)

func main() {
	port, err := startWebServer(3000)

	if err != nil {
		log.Fatal(err)
	}

	fmt.Printf("Server is running at port: %d", port)
}

func startWebServer(port int) (int, error) {
	number := randomInt(0, 2)

	if number <= 0 {
		return port, errors.New("something went wrong")
	}

	return port, nil
}

func randomInt(min, max int) int {
	rand.Seed(time.Now().UnixNano())

	return rand.Intn(max-min) + min
}
