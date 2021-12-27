package main

import (
	"io"
	"os"
)

func main() {
	Greet(os.Stdout, "Frank")
}

func Greet(w io.Writer, msg string) {
	w.Write([]byte("Hello, " + msg))
}
