package main

import (
	"fmt"
	"io"
)

const (
	countdownStart = 3
	finalWord      = "GO!"
)

func Countdown(b io.Writer) {
	for i := countdownStart; i > 0; i-- {
		fmt.Fprintf(b, "%d\n", i)
	}

	fmt.Fprintln(b, finalWord)
}
