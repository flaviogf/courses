package main

import (
	"net/http"
)

func main() {
}

func Racer(firstURL, secondURL string) string {
	select {
	case <-ping(firstURL):
		return firstURL
	case <-ping(secondURL):
		return secondURL
	}
}

func ping(url string) chan struct{} {
	cn := make(chan struct{})

	go func(url string) {
		http.Get(url)
		close(cn)
	}(url)

	return cn
}
