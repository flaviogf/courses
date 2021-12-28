package main

import (
	"fmt"
	"io"
)

func Countdown(b io.Writer) {
	for i := 3; i > 0; i-- {
		fmt.Fprintf(b, "%d\n", i)
	}

	fmt.Fprintln(b, "GO!")
}
