package main

import (
	"io"
	"net"
	"testing"
)

func TestDial(t *testing.T) {
	signal := make(chan struct{})

	l, err := net.Listen("tcp", "127.0.0.1:0")

	if err != nil {
		t.Fatal(err)
	}

	go func(l net.Listener) {
		defer func() {
			defer l.Close()
			signal <- struct{}{}
		}()

		conn, err := l.Accept()

		if err != nil {
			t.Fatal(err)
		}

		go func(conn net.Conn) {
			defer func() {
				defer conn.Close()
				signal <- struct{}{}
			}()

			buf := make([]byte, 1024)

			n, err := conn.Read(buf)

			if err != nil && err != io.EOF {
				t.Fatal(err)
			}

			t.Logf("received: %q", buf[:n])
		}(conn)
	}(l)

	conn, err := net.Dial("tcp", l.Addr().String())

	if err != nil {
		t.Fatal(err)
	}

	defer conn.Close()

	conn.Write([]byte("Hey"))
	<-signal
	<-signal
}
