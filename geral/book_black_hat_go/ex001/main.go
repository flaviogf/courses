package main

import (
	"io"
	"net"
	"os"
)

func main() {
	Scan(os.Stdout, "scanme.nmap.org:80")
}

func Scan(w io.Writer, url string) {
	_, err := net.Dial("tcp", url)

	if err == nil {
		w.Write([]byte("Connection successful\n"))
	}
}
