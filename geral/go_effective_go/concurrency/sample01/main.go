package main

import (
	"fmt"
	"sort"
)

func main() {
	ch := make(chan int)

	ages := []int{62, 25, 51, 28}

	fmt.Println(ages)

	go func() {
		fmt.Println("sorting...")
		sort.Ints(ages)
		fmt.Println("sort finished")
		ch <- 1
	}()

	fmt.Println("doing something...")

	<-ch

	fmt.Println(ages)
}
