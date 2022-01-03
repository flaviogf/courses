package main

import (
	"bufio"
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

	r := bufio.NewReader(conn)

	s, err := r.ReadString('\n')

	if err != nil {
		log.Fatal(err)
	}

	fmt.Printf("received: %s\n", s)

	w := bufio.NewWriter(conn)

	_, err = w.WriteString(s)

	if err != nil {
		log.Fatal(err)
	}

	err = w.Flush()

	if err != nil {
		log.Fatal(err)
	}
}
