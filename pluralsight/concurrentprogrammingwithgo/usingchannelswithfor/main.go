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
		for i := range ch {
			fmt.Printf("message received: %d\n", i)
		}

		wg.Done()
	}(ch, wg)

	go func(ch chan<- int, wg *sync.WaitGroup) {
		for i := 0; i < 10; i++ {
			ch <- i
			fmt.Printf("message sent: %d\n", i)
		}

		close(ch)

		wg.Done()
	}(ch, wg)

	wg.Wait()
}
