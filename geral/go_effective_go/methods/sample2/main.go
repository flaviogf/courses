package main

import (
	"fmt"
	"net/http"
	"sync"
)

func main() {
	c := Counter{}
	http.Handle("/counter", &c)
	http.ListenAndServe(":8080", nil)
}

type Counter struct {
	n int32
	m sync.Mutex
}

func (c *Counter) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	c.m.Lock()
	defer c.m.Unlock()

	c.n++

	fmt.Fprintf(w, "counter=%d\n", c.n)
}
