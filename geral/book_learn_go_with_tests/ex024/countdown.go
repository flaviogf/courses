package main

import (
	"fmt"
	"io"
)

func Countdown(b io.Writer) {
	fmt.Fprintf(b, "%d", 3)
}
