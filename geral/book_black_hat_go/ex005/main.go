package main

import (
	"fmt"
	"sync"
)

func main() {
	ports := make(chan int, 100)
	wg := &sync.WaitGroup{}

	for i := 0; i < cap(ports); i++ {
		go func(worker int) {
			for port := range ports {
				fmt.Printf("worker: %d, port: %d\n", worker, port)
				wg.Done()
			}
		}(i)
	}

	for i := 1; i <= 1024; i++ {
		wg.Add(1)
		ports <- i
	}

	wg.Wait()
	close(ports)
}
