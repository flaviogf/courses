package messages

import "testing"

func TestGreet(t *testing.T) {
	got := Greet("Gopher")

	expected := "Hello, Gopher!\n"

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}

func TestGreetTableDriven(t *testing.T) {
	scenarios := []struct {
		input    string
		expected string
	}{
		{"Gopher", "Hello, Gopher!\n"},
		{"", "Hello, !\n"},
	}

	for _, it := range scenarios {
		got := Greet(it.input)

		if got != it.expected {
			t.Errorf("Did not get expected result for input %v. Got: %v, Want: %v", it.input, got, it.expected)
		}
	}
}

func TestDepart(t *testing.T) {
	got := depart("Gopher")

	expected := "Goodbye, Gopher"

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}
