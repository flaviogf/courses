package main

import (
	"bytes"
	"testing"
)

type FakePersonRepository struct{}

func (r *FakePersonRepository) GetPerson(name string) (*Person, error) {
	return &Person{"Frank", "How are you doing?"}, nil
}

func TestSayHello(t *testing.T) {
	w := &bytes.Buffer{}
	r := &FakePersonRepository{}

	err := SayHello(w, r, "Frank")

	if err != nil {
		t.Error("did not want an error, but got one")
	}

	expectedResult := "Hello, Frank! How are you doing?"

	result := w.String()

	if result != expectedResult {
		t.Errorf("got: %s, want: %s\n", result, expectedResult)
	}
}
