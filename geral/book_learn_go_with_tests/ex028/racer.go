package main

import (
	"net/http"
	"time"
)

func main() {
}

func Racer(firstURL, secondURL string) string {
	start := time.Now()
	http.Get(firstURL)
	r1 := time.Since(start)

	start = time.Now()
	http.Get(secondURL)
	r2 := time.Since(start)

	if r1 > r2 {
		return secondURL
	}

	return firstURL
}
