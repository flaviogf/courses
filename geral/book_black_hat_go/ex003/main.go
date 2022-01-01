package main

import (
	"fmt"
	"io"
)

func Scan(w io.Writer, url string, port int, fn func(network, address string) (io.Closer, error)) error {
	conn, err := fn("tcp", fmt.Sprintf("%s:%d", url, port))

	if err != nil {
		return err
	}

	defer conn.Close()

	w.Write([]byte(fmt.Sprintf("%d open\n", port)))

	return nil
}
