package main

import (
	"flag"
	"fmt"
	"log"
	"net/http"
	"strings"
)

var urlStringVar string

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
	flag.StringVar(&urlStringVar, "url", "", "a comma-separate list of URLs")
}

func main() {
	flag.Parse()

	if urlStringVar == "" {
		log.Fatal("you must specify at least one URL")
	}

	urls := strings.Split(urlStringVar, ",")

	if len(urls) == 0 {
		log.Fatal("you must specify at least one URL")
	}

	c := &HttpChecker{}

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
