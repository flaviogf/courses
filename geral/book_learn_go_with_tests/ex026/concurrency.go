package main

import (
	"fmt"
	"net/http"
)

type Checker interface {
	Check(url string) bool
}

type HttpChecker struct{}

func (hc *HttpChecker) Check(url string) bool {
	resp, err := http.Get(url)

	if err != nil {
		return false
	}

	return resp.StatusCode == 200
}

func main() {
	c := &HttpChecker{}

	urls := []string{
		"https://www.google.com",
		"https://www.youtube.com",
	}

	result := CheckWebsites(c, urls)

	fmt.Printf("%v\n", result)
}

func CheckWebsites(c Checker, urls []string) map[string]bool {
	result := make(map[string]bool)

	for _, url := range urls {
		result[url] = c.Check(url)
	}

	return result
}
