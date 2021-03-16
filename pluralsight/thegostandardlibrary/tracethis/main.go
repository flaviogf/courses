package main

import (
	"fmt"
	"log"
	"math/rand"
	"os"
	"runtime/trace"
	"time"
)

func main() {
	file, err := os.Create("trace.out")

	if err != nil {
		log.Fatalf("We did not create a trace file! %v\n", err)
	}

	defer func() {
		if err = file.Close(); err != nil {
			log.Fatalf("Failed to close trace file %v\n", err)
		}
	}()

	if err = trace.Start(file); err != nil {
		log.Fatalf("We failed to start a trace: %v\n", err)
	}

	defer trace.Stop()

	AddRandomNumbers()
}

func AddRandomNumbers() {
	firstNumber := rand.Int()

	secondNumber := rand.Int()

	time.Sleep(2 * time.Second)

	result := firstNumber * secondNumber

	fmt.Printf("Result between these numbers are %v\n", result)
}
