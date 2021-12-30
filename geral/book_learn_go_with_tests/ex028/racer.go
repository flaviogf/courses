package main

import (
	"errors"
	"fmt"
	"log"
	"net/http"
	"time"
)

func main() {
	resp, err := Racer("https://google.com", "https://alura.com")

	if err != nil {
		log.Fatal(err)
	}

	fmt.Println(resp)
}

func Racer(firstURL, secondURL string) (string, error) {
	return ConfigurableRacer(firstURL, secondURL, 10*time.Second)
}

func ConfigurableRacer(firstURL, secondURL string, delay time.Duration) (string, error) {
	select {
	case <-ping(firstURL):
		return firstURL, nil
	case <-ping(secondURL):
		return secondURL, nil
	case <-time.After(delay):
		return "", errors.New("timed out")
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
