package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"regexp"
)

func main() {
	c := juntar(
		titulo("https://www.cod3r.com.br", "https://www.google.com"),
		titulo("https://amazon.com", "https://www.youtube.com"),
	)

	fmt.Println(<-c, "|", <-c)
	fmt.Println(<-c, "|", <-c)
}

func juntar(entrada1, entrada2 chan string) chan string {
	c := make(chan string)

	go func() {
		for {
			select {
			case s := <-entrada1:
				c <- s
			case s := <-entrada2:
				c <- s
			}
		}
	}()

	return c
}

func titulo(urls ...string) chan string {
	c := make(chan string)

	for _, url := range urls {
		go func(url string) {
			resp, _ := http.Get(url)

			html, _ := ioutil.ReadAll(resp.Body)

			r, _ := regexp.Compile("<title>(.*?)</title>")

			c <- r.FindStringSubmatch(string(html))[0]
		}(url)
	}

	return c
}
