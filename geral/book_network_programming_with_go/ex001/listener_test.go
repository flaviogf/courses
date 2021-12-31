package main

import (
	"net"
	"testing"
)

func TestListener(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:0")

	if err != nil {
		t.Fatal(err)
	}

	defer l.Close()

	t.Logf("bound to %q", l.Addr())
}
