package main

import (
	"fmt"
	"sync"
)

func main() {
	wg := &sync.WaitGroup{}

	ch := make(chan int)

	wg.Add(2)

	go func(ch chan int, wg *sync.WaitGroup) {
		message := <-ch
		fmt.Printf("message received: %d\n", message)
		wg.Done()
	}(ch, wg)

	go func(ch chan int, wg *sync.WaitGroup) {
		message := 42
		ch <- message
		fmt.Printf("message sent: %d\n", message)
		wg.Done()
	}(ch, wg)

	wg.Wait()
}
