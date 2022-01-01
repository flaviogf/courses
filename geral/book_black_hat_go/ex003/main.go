package main

import (
	"fmt"
	"io"
	"net"
	"os"
)

func main() {
	for i := 1; i <= 1024; i++ {
		Scan(os.Stdout, "scanme.nmap.org", i, net.Dial)
	}
}

func Scan(w io.Writer, url string, port int, fn func(network, address string) (net.Conn, error)) error {
	conn, err := fn("tcp", fmt.Sprintf("%s:%d", url, port))

	if err != nil {
		return err
	}

	defer conn.Close()

	w.Write([]byte(fmt.Sprintf("%d open\n", port)))

	return nil
}
