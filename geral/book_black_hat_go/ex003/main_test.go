package main

import (
	"bytes"
	"errors"
	"testing"
)

type DoubleCloser struct {
	Calls int
}

func (dc *DoubleCloser) Close() error {
	dc.Calls += 1
	return nil
}

func TestScan(t *testing.T) {
	buf := &bytes.Buffer{}
	url := "scanme.nmap.org"
	port := 80
	c := &DoubleCloser{}

	_ = Scan(buf, url, port, func(_, _ string) (Closer, error) {
		return c, nil
	})

	got := buf.String()
	want := "80 open\n"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}

	t.Run("when something goes wrong", func(t *testing.T) {
		buf := &bytes.Buffer{}
		url := "scanme.nmap.org"
		port := 80

		err := Scan(buf, url, port, func(_, _ string) (Closer, error) {
			return nil, errors.New("ops")
		})

		if err == nil {
			t.Error("did not get an error but wanted one")
		}
	})
}
