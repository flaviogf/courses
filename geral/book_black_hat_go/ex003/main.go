package main

import (
	"fmt"
	"io"
)

type Conn interface {
	Close() error
}

func Scan(w io.Writer, url string, port int, fn func(network, address string) (Conn, error)) error {
	conn, err := fn("tcp", fmt.Sprintf("%s:%d", url, port))

	if err != nil {
		return err
	}

	defer conn.Close()

	w.Write([]byte(fmt.Sprintf("%d open\n", port)))

	return nil
}
