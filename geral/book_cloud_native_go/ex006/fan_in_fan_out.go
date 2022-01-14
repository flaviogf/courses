package main

func FanInFanOut(channels []chan int) chan int {
	cout := make(chan int)

	go func() {
		for _, channel := range channels {
			for i := range channel {
				cout <- i
			}
		}

		close(cout)
	}()

	return cout
}
