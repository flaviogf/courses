package main

import (
	"bytes"
	"reflect"
	"testing"
)

const (
	sleep = "sleep"
	write = "write"
)

type SpySleeperWriter struct {
	Calls []string
}

func (s *SpySleeperWriter) Sleep() {
	s.Calls = append(s.Calls, sleep)
}

func (s *SpySleeperWriter) Write(b []byte) (int, error) {
	s.Calls = append(s.Calls, write)
	return 0, nil
}

func TestCountdown(t *testing.T) {
	b := &bytes.Buffer{}
	s := &SpySleeperWriter{}

	Countdown(b, s)

	got := b.String()
	want := `3
2
1
GO!
`

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}

	t.Run("it sleeps before each print", func(t *testing.T) {
		s := &SpySleeperWriter{}

		Countdown(s, s)

		want := []string{
			sleep,
			write,
			sleep,
			write,
			sleep,
			write,
			sleep,
			write,
		}

		got := s.Calls

		if !reflect.DeepEqual(got, want) {
			t.Errorf("got: %q, want: %q", got, want)
		}
	})
}
