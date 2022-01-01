package main

import (
	"bytes"
	"fmt"
	"net"
	"strings"
	"testing"
)

func TestScan(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:")

	if err != nil {
		t.Fatal(err)
	}

	defer l.Close()

	b := &bytes.Buffer{}
	url := l.Addr().String()
	low := 1
	high := 10
	Scan(b, url, low, high)

	builder := &strings.Builder{}
	for i := low; i <= high; i++ {
		builder.WriteString(fmt.Sprintf("%s:%d\n", url, i))
	}

	got := b.String()
	want := builder.String()

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}
