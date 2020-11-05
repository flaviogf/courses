package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	if i := numeroAleatorio(); i > 5 {
		fmt.Println("Ganhou!!!")
	} else {
		fmt.Println("Perdeu!")
	}
}

func numeroAleatorio() int {
	r := rand.New(rand.NewSource(time.Now().UnixNano()))

	return r.Intn(10)
}
