package main

import (
	"fmt"
	"sync"
)

func main() {
	wg := &sync.WaitGroup{}

	ch := make(chan int)

	wg.Add(2)

	go func(ch <-chan int, wg *sync.WaitGroup) {
		if m, ok := <-ch; ok {
			fmt.Printf("message received: %d\n", m)
		} else {
			fmt.Println("nothing received, because the channel is closed")
		}

		wg.Done()
	}(ch, wg)

	go func(ch chan<- int, wg *sync.WaitGroup) {
		// ch <- 0

		close(ch)

		wg.Done()
	}(ch, wg)

	wg.Wait()
}
