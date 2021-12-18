package main

import "testing"

func TestHello(t *testing.T) {
	t.Run("when name is empty", func(t *testing.T) {
		got := Hello("")
		want := "Hello, world"

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	})

	t.Run("when name is not empty", func(t *testing.T) {
		got := Hello("Flavio")
		want := "Hello, Flavio"

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	})
}
