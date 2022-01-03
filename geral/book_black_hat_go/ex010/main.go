package main

import (
	"fmt"
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

	fmt.Println("It works")
}
