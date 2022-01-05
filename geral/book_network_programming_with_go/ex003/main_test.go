package main

import (
	"context"
	"net"
	"syscall"
	"testing"
	"time"
)

func TestDialContext(t *testing.T) {
	ctx, cancel := context.WithDeadline(context.Background(), time.Now().Add(4*time.Millisecond))

	defer cancel()

	var d net.Dialer

	d.Control = func(_, _ string, _ syscall.RawConn) error {
		time.Sleep(5 * time.Millisecond)
		return nil
	}

	_, err := d.DialContext(ctx, "tcp", ":8080")

	if err == nil {
		t.Fatal("did not get an error, but would want one")
	}

	if _, ok := err.(net.Error); !ok {
		t.Fatal("did not get an net.Error, but would want one")
	}
}
