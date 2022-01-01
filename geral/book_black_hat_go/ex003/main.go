package main

import (
	"fmt"
	"io"
)

type Closer interface {
	Close() error
}

func main() {
}

func Scan(w io.Writer, url string, port int, fn func(network, address string) (Closer, error)) error {
	conn, err := fn("tcp", fmt.Sprintf("%s:%d", url, port))

	if err != nil {
		return err
	}

	defer conn.Close()

	w.Write([]byte(fmt.Sprintf("%d open\n", port)))

	return nil
}
