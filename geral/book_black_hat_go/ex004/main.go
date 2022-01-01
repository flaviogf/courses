package main

import (
	"fmt"
	"io"
	"net"
	"os"
	"sync"
	"time"
)

type Finisher interface {
	Done()
}

func main() {
	wg := &sync.WaitGroup{}

	for i := 1; i <= 1024; i++ {
		wg.Add(1)

		d := net.Dialer{Timeout: 10 * time.Second}
		go Scan(os.Stdout, "scanme.nmap.org", i, wg, d.Dial)
	}

	wg.Wait()
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
