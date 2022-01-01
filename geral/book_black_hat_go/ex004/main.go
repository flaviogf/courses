package main

import (
	"fmt"
	"io"
	"net"
)

type Finisher interface {
	Done()
}

func Scan(w io.Writer, url string, port int, f Finisher, fn func(network, address string) (net.Conn, error)) error {
	defer f.Done()

	conn, err := fn("tcp", fmt.Sprintf("%s:%d", url, port))

	if err != nil {
		return err
	}

	defer conn.Close()

	w.Write([]byte(fmt.Sprintf("%d open\n", port)))

	return nil
}
