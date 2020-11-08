package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"regexp"
)

func main() {
	t1 := titulos("https://www.cod3r.com.br", "https://www.google.com.br")
	t2 := titulos("https://www.amazon.com", "https://www.youtube.com.br")
	fmt.Println("Primeiros:", <-t1, "|", <-t2)
	fmt.Println("Segundos:", <-t1, "|", <-t2)
}

func titulos(urls ...string) chan string {
	ch := make(chan string)

	for _, url := range urls {
		go func(url string) {
			resp, _ := http.Get(url)

			html, _ := ioutil.ReadAll(resp.Body)

			r, _ := regexp.Compile("<title>(.*?)</title>")

			ch <- r.FindStringSubmatch(string(html))[0]
		}(url)
	}

	return ch
}
