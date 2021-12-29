package main

import (
	"flag"
	"fmt"
	"log"
	"net/http"
	"strings"
)

var urls string

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

func init() {
	flag.StringVar(&urls, "urls", "", "a separate list of URLs by comma")
}

func main() {
	flag.Parse()

	if urls == "" {
		log.Fatal("you must specify at least one url")
	}

	c := &HttpChecker{}

	result := CheckWebsites(c, strings.Split(urls, ","))

	fmt.Printf("%v\n", result)
}

func CheckWebsites(c Checker, urls []string) map[string]bool {
	result := make(map[string]bool)

	for _, url := range urls {
		result[url] = c.Check(url)
	}

	return result
}
