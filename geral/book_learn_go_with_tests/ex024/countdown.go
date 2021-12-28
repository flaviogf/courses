package main

import (
	"fmt"
	"io"
	"os"
	"time"
)

const (
	countdownStart = 3
	finalWord      = "GO!"
)

func main() {
	Countdown(os.Stdout)
}

func Countdown(b io.Writer) {
	for i := countdownStart; i > 0; i-- {
		time.Sleep(1 * time.Second)
		fmt.Fprintf(b, "%d\n", i)
	}

	time.Sleep(1 * time.Second)
	fmt.Fprintln(b, finalWord)
}
