package main

import (
	"fmt"
	"time"
)

func main() {
	before := time.Now()

	fmt.Printf("before: %s\n", before.Format("15:04:05"))

	time.Sleep(2 * time.Second)

	after := time.Now()

	fmt.Printf("after: %s\n", after.Format("15:04:05"))

	startDate := time.Date(1997, 6, 13, 9, 0, 0, 0, time.UTC)

	elapsed := time.Since(startDate)

	fmt.Printf("Hours: %.2f, Minutes: %.2f\n", elapsed.Hours(), elapsed.Minutes())
}
