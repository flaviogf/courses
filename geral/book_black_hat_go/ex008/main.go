package main

import (
	"fmt"
	"io"
	"log"
	"os"
)

type FooReader struct{}

func (f *FooReader) Read(b []byte) (int, error) {
	fmt.Print("in > ")
	return os.Stdin.Read(b)
}

type FooWriter struct{}

func (f *FooWriter) Write(b []byte) (int, error) {
	fmt.Print("out> ")
	return os.Stdout.Write(b)
}

func main() {
	var (
		r FooReader
		w FooWriter
	)

	if _, err := io.Copy(&w, &r); err != nil {
		log.Fatal(err)
	}
}
