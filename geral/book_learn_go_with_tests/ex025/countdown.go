package main

import (
	"fmt"
	"io"
)

func Countdown(w io.Writer) {
	fmt.Fprintf(w, "%d", 3)
}
