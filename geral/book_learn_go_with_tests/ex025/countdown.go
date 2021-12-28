package main

import (
	"fmt"
	"io"
)

const (
	countdownStart = 3
	finalWord      = "GO!"
)

func Countdown(w io.Writer) {
	for i := countdownStart; i > 0; i-- {
		fmt.Fprintf(w, "%d\n", i)
	}

	fmt.Fprintln(w, finalWord)
}
