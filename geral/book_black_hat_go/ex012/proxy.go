package main

import (
	"io"
	"log"
	"net"
)

func main() {
	l, err := net.Listen("tcp", ":3000")

	if err != nil {
		log.Fatal(err)
	}

	for {
		conn, err := l.Accept()

		if err != nil {
			log.Fatal(err)
		}

		go handle(conn)
	}
}

func handle(src net.Conn) {
	dst, err := net.Dial("tcp", ":8080")

	if err != nil {
		log.Fatal(err)
	}

	go copy(dst, src)

	copy(src, dst)
}

func copy(dst, src io.ReadWriteCloser) {
	if _, err := io.Copy(dst, src); err != nil {
		log.Fatal(err)
	}
}
