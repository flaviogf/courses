package main

import (
	"fmt"
	"time"
)

func main() {
	ch1 := make(chan int, 1)

	ch1 <- 1
	<-ch1

	ch1 <- 2
	fmt.Println(<-ch1)

	ch2 := make(chan int)

	go doisTresQuatroVezes(2, ch2)

	a, b := <-ch2, <-ch2
	fmt.Println(a, b)
	fmt.Println(<-ch2)
}

func doisTresQuatroVezes(base int, ch chan int) {
	time.Sleep(time.Second)

	ch <- base * 2

	time.Sleep(time.Second)

	ch <- base * 3

	time.Sleep(time.Second)

	ch <- base * 4
}
