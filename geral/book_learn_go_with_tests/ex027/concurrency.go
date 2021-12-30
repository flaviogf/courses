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

type result struct {
	string
	bool
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

	fmt.Printf("%v\n", CheckWebsites(&HttpChecker{}, urls))
}

func CheckWebsites(c Checker, urls []string) map[string]bool {
	results := make(map[string]bool)
	cn := make(chan result)

	for _, url := range urls {
		go func(url string) {
			cn <- result{url, c.Check(url)}
		}(url)
	}

	for i := 0; i < len(urls); i++ {
		r := <-cn
		results[r.string] = r.bool
	}

	return results
}
