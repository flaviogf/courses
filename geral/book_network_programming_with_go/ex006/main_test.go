package main

import (
	"io"
	"net"
	"testing"
	"time"
)

func TestDeadline(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:")

	if err != nil {
		t.Fatal(err)
	}

	signal := make(chan struct{})

	go func() {
		conn, err := l.Accept()

		if err != nil {
			t.Fatal(err)
		}

		defer func() {
			conn.Close()
			close(signal)
		}()

		err = conn.SetDeadline(time.Now().Add(5 * time.Second))

		if err != nil {
			t.Fatal(err)
		}

		buf := make([]byte, 512)

		_, err = conn.Read(buf)

		if nErr, ok := err.(net.Error); !ok && !nErr.Temporary() {
			t.Fatal(nErr)
		}

		signal <- struct{}{}

		err = conn.SetDeadline(time.Now().Add(5 * time.Second))

		if err != nil {
			t.Fatal(err)
		}

		n, err := conn.Read(buf)

		if err != nil {
			t.Fatal(err)
		}

		got := string(buf[:n])
		want := "Hello\n"

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	}()

	conn, err := net.Dial("tcp", l.Addr().String())

	if err != nil {
		t.Fatal(err)
	}

	defer conn.Close()

	<-signal

	_, err = conn.Write([]byte("Hello\n"))

	if err != nil {
		t.Fatal(err)
	}

	buf := make([]byte, 1)

	_, err = conn.Read(buf)

	if err != io.EOF {
		t.Fatal(err)
	}
}
