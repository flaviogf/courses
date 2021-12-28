package main

import (
	"fmt"
	"io"
	"os"
	"time"
)

type Sleeper interface {
	Sleep()
}

type DefaultSleeper struct{}

func (d *DefaultSleeper) Sleep() {
	time.Sleep(1 * time.Second)
}

const (
	countdownStart = 3
	finalWord      = "GO!"
)

func main() {
	s := &DefaultSleeper{}
	Countdown(os.Stdout, s)
}

func Countdown(w io.Writer, s Sleeper) {
	for i := countdownStart; i > 0; i-- {
		s.Sleep()
		fmt.Fprintf(w, "%d\n", i)
	}

	s.Sleep()
	fmt.Fprintln(w, finalWord)
}
