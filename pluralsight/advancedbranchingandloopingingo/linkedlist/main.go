package main

import (
	"fmt"
	"math/rand"
	"time"
)

type Child struct {
	Value   int
	Pointer *Child
}

func main() {
	rand.Seed(time.Now().Unix())

	child := createLinkedList(5, nil)

	for ; child != nil; child = child.Pointer {
		fmt.Printf("%v\n", child.Value)
	}
}

func createLinkedList(times int, head *Child) *Child {
	if head == nil {
		head = &Child{rand.Intn(100), nil}

		times--
	}

	current := head

	for i := 0; i < times; i++ {
		child := &Child{rand.Intn(100), nil}

		current.Pointer = child

		current = child
	}

	return head
}
