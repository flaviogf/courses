package main

import (
	"io"
	"log"
	"net"
)

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

		go echo(conn)
	}
}

func echo(conn io.ReadWriteCloser) {
	defer conn.Close()

	if _, err := io.Copy(conn, conn); err != nil {
		log.Fatal(err)
	}
}
