package main

import (
	"bytes"
	"testing"
)

func TestGreet(t *testing.T) {
	b := &bytes.Buffer{}
	Greet(b, "Frank")
	assertEqual(t, b.String(), "Hello, Frank")
}

func assertEqual(t testing.TB, got, want string) {

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}
