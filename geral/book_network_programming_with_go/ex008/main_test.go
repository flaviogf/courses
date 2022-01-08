package main

import (
	"bufio"
	"fmt"
	"io/ioutil"
	"net"
	"os"
	"path/filepath"
	"testing"
)

func TestUnixDomainSocket(t *testing.T) {
	dir, err := ioutil.TempDir(os.TempDir(), "*_echo_unix")

	if err != nil {
		t.Fatal(err)
	}

	defer func() {
		if rErr := os.RemoveAll(dir); rErr != nil {
			t.Fatal(rErr)
		}
	}()

	socket := filepath.Join(dir, fmt.Sprintf("%d.sock", os.Getpid()))

	l, err := net.Listen("unix", socket)

	if err != nil {
		t.Fatal(err)
	}

	go func() {
		for {
			conn, err := l.Accept()

			if err != nil {
				t.Fatal(err)
			}

			go func(conn net.Conn) {
				defer conn.Close()

				w := bufio.NewWriter(conn)

				_, err = w.WriteString("OK\n")

				if err != nil {
					t.Fatal(err)
				}

				err = w.Flush()

				if err != nil {
					t.Fatal(err)
				}
			}(conn)
		}
	}()

	conn, err := net.Dial("unix", l.Addr().String())

	if err != nil {
		t.Fatal(err)
	}

	defer conn.Close()

	r := bufio.NewReader(conn)

	resp, err := r.ReadString('\n')

	if err != nil {
		t.Fatal(err)
	}

	t.Log(resp)
}
