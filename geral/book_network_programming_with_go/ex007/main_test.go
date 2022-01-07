package main

import (
	"bufio"
	"log"
	"net"
	"testing"
)

func TestReadIntoBuffer(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:")

	if err != nil {
		t.Fatal(err)
	}

	go func() {
		conn, err := l.Accept()

		if err != nil {
			t.Fatal(err)
		}

		defer conn.Close()

		w := bufio.NewWriter(conn)

		_, err = w.WriteString("{\"status\": \"ok\"}\n")

		if err != nil {
			t.Fatal(err)
		}

		err = w.Flush()

		if err != nil {
			log.Fatal(err)
		}
	}()

	conn, err := net.Dial("tcp", l.Addr().String())

	if err != nil {
		t.Fatal(err)
	}

	r := bufio.NewReader(conn)

	resp, err := r.ReadString('\n')

	if err != nil {
		t.Fatal(err)
	}

	t.Log(resp)
}
