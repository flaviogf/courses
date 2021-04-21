package main

import "fmt"

type Node struct {
	Value int
	Prev  *Node
	Next  *Node
}

func NewNode(value int, prev, next *Node) *Node {
	return &Node{
		Value: value,
		Prev:  prev,
		Next:  next,
	}
}

type LinkedList struct {
	Head *Node
	Tail *Node
}

func NewLinkedList() *LinkedList {
	return &LinkedList{}
}

func (ll *LinkedList) Add(value int) {
	if ll.Head == nil {
		node := NewNode(value, nil, nil)
		ll.Head = node
		ll.Tail = node
	} else {
		node := NewNode(value, nil, ll.Head)
		ll.Head.Prev = node
		ll.Head = node
	}
}

func (ll *LinkedList) Remove() {
	if ll.Tail != nil {
		ll.Tail = ll.Tail.Prev
		ll.Tail.Next = nil
	}
}

func (ll *LinkedList) Print() {
	current := ll.Head

	for current != nil {
		fmt.Printf("%p - %+v\n", current, current)
		current = current.Next
	}
}

func main() {
	list := NewLinkedList()

	fmt.Println("Adding 10 O(1)")
	list.Add(10)

	fmt.Println("Adding 20 O(1)")
	list.Add(20)

	fmt.Println("Adding 30 O(1)")
	list.Add(30)

	fmt.Println("Adding 40 O(1)")
	list.Add(40)

	fmt.Printf("Head: %d O(1)\n", list.Head.Value)

	fmt.Printf("Tail: %d O(1)\n", list.Tail.Value)

	fmt.Printf("Elements: O(n)\n")

	list.Print()

	fmt.Println("Removing last O(1)")
	list.Remove()

	fmt.Println("Removing last O(1)")
	list.Remove()

	fmt.Printf("Elements: O(n)\n")

	list.Print()
}
