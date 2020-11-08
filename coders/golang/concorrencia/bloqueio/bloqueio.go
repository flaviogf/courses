package main

import (
	"fmt"
	"time"
)

func main() {
	c := make(chan int)

	go rotina(c)

	fmt.Println(<-c)
	fmt.Println("Foi lido")
	fmt.Println(<-c)
	fmt.Println("Fim")
}

func rotina(c chan int) {
	time.Sleep(time.Second)
	c <- 1
	fmt.Println("Só depois que foi lido")
}
