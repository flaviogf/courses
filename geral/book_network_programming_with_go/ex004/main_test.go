package main

import (
	"context"
	"net"
	"syscall"
	"testing"
	"time"
)

func TestDialContext(t *testing.T) {
	ctx, cancel := context.WithCancel(context.Background())
	signal := make(chan struct{})

	go func() {
		defer func() { signal <- struct{}{} }()

		var d net.Dialer

		d.Control = func(_, _ string, _ syscall.RawConn) error {
			time.Sleep(time.Second)
			return nil
		}

		conn, err := d.DialContext(ctx, "tcp", ":80")

		if err != nil {
			return
		}

		defer conn.Close()

		t.Fatal("dial did not fail")
	}()

	cancel()
	<-signal

	if err := ctx.Err(); err != context.Canceled {
		t.Fatal("did not get an error, but would want one")
	}
}
