package messages

import "testing"

func TestGreet(t *testing.T) {
	got := Greet("Gopher")

	expected := "Hello, Gopher!\n"

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}

func TestDepart(t *testing.T) {
	got := depart("Gopher")

	expected := "Goodbye, Gopher"

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}
