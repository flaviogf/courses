package main

import (
	"fmt"
	"io"
	"os"
)

func main() {
	Scan(os.Stdout, "scanme.nmap.org", 1, 1024)
}

func Scan(w io.Writer, url string, low, high int) {
	for i := low; i <= high; i++ {
		addr := fmt.Sprintf("%s:%d", url, i)
		w.Write([]byte(addr + "\n"))
	}
}
