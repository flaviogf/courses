package main

func FanOut(source chan int, n int) []chan int {
	dests := make([]chan int, 0)

	for i := 0; i < n; i++ {
		dest := make(chan int)
		dests = append(dests, dest)

		go func(dest chan<- int) {
			for i := range source {
				dest <- i
			}

			close(dest)
		}(dest)
	}

	return dests
}
