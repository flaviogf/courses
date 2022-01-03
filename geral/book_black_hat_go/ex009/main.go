package main

import (
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

func echo(conn net.Conn) {
	defer conn.Close()

	b := make([]byte, 512)

	n, err := conn.Read(b)

	if err != nil {
		log.Fatal(err)
	}

	log.Printf("received: %s", string(b[:n]))

	_, err = conn.Write(b[:n])

	if err != nil {
		log.Fatal(err)
	}
}
