package main

import (
	"bytes"
	"testing"
)

type SpySleeper struct {
	Calls int
}

func (s *SpySleeper) Sleep() {
	s.Calls += 1
}

func TestCountdown(t *testing.T) {
	b := &bytes.Buffer{}
	spySleeper := &SpySleeper{}

	Countdown(b, spySleeper)

	got := b.String()
	want := `3
2
1
GO!
`

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}

	if spySleeper.Calls != 4 {
		t.Errorf("wanted sleeper to have been called 4 times but got %d", spySleeper.Calls)
	}
}
