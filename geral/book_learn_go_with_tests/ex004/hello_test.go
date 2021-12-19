package main

import "testing"

func TestHello(t *testing.T) {
	assertCorretMessage := func(t testing.TB, got, want string) {
		t.Helper()

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	}

	t.Run("when name and language are empty", func(t *testing.T) {
		got := Hello("", "")
		want := "Hello, world"
		assertCorretMessage(t, got, want)
	})

	t.Run("when name is not empty", func(t *testing.T) {
		got := Hello("Frank", "")
		want := "Hello, Frank"
		assertCorretMessage(t, got, want)
	})

	t.Run("when language is Spanish", func(t *testing.T) {
		got := Hello("Frank", "Spanish")
		want := "Hola, Frank"
		assertCorretMessage(t, got, want)
	})

	t.Run("when language is French", func(t *testing.T) {
		got := Hello("Frank", "French")
		want := "Bonjour, Frank"
		assertCorretMessage(t, got, want)
	})
}
