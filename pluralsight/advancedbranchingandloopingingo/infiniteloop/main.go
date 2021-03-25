package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	rand.Seed(time.Now().UnixNano())

	findRandomNumber(rand.Intn(100))
}

func findRandomNumber(randomNumber int) {
	count := 0

	for {
		guessedNumber := rand.Intn(10000)

		if randomNumber == guessedNumber {
			break
		}

		count++
	}

	fmt.Printf("Number %d found after %d attempt(s)", randomNumber, count)
}
