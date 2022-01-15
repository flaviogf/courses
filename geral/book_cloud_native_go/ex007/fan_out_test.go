package main

import (
	"sync"
	"testing"
)

func TestFanOut(t *testing.T) {
	source := make(chan int)

	go func(source chan int) {
		for i := 0; i < 10; i++ {
			source <- i
		}

		close(source)
	}(source)

	dests := FanOut(source, 5)

	wg := sync.WaitGroup{}

	for _, dest := range dests {
		wg.Add(1)

		go func(dest <-chan int) {
			for i := range dest {
				t.Log(i)
			}

			wg.Done()
		}(dest)
	}

	wg.Wait()
}
