package main

import (
	"fmt"
	"log"
	"os"
)

type FooReader struct{}

func (f *FooReader) Read(b []byte) (int, error) {
	fmt.Print("in> ")
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

	b := make([]byte, 4096)

	_, err := r.Read(b)

	if err != nil {
		log.Fatal(err)
	}

	_, err = w.Write(b)

	if err != nil {
		log.Fatal(err)
	}
}
