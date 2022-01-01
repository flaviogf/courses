package main

import (
	"bytes"
	"net"
	"testing"
)

func TestScan(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:")

	if err != nil {
		t.Fatal(err)
	}

	defer l.Close()

	url := l.Addr().String()
	b := &bytes.Buffer{}
	Scan(b, url)

	got := b.String()
	want := "Connection successful\n"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}
