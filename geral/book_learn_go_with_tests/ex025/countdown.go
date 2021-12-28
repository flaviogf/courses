package main

import (
	"fmt"
	"io"
)

type Sleeper interface {
	Sleep()
}

const (
	countdownStart = 3
	finalWord      = "GO!"
)

func Countdown(w io.Writer, s Sleeper) {
	for i := countdownStart; i > 0; i-- {
		s.Sleep()
		fmt.Fprintf(w, "%d\n", i)
	}

	s.Sleep()
	fmt.Fprintln(w, finalWord)
}
