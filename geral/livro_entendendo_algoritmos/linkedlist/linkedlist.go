package main

import "fmt"

type Node struct {
	Value int
	Next  *Node
}

func NewNode(value int, next *Node) *Node {
	return &Node{
		Value: value,
		Next:  next,
	}
}

type LinkedList struct {
	Head *Node
}

func NewLinkedList() *LinkedList {
	return &LinkedList{}
}

func (l *LinkedList) Prepend(value int) {
	l.Head = NewNode(value, l.Head)
}

func (l *LinkedList) Append(value int) {
	if l.Head == nil {
		l.Head = NewNode(value, nil)
		return
	}

	current := l.Head

	for current.Next != nil {
		current = current.Next
	}

	current.Next = NewNode(value, nil)
}

func (l *LinkedList) Remove(value int) {
	if l.Head == nil {
		return
	}

	if l.Head.Value == value {
		l.Head = l.Head.Next
		return
	}

	current := l.Head

	for current.Next != nil {
		if current.Next.Value == value {
			current.Next = current.Next.Next
			return
		}

		current = current.Next
	}
}

func main() {
	list := NewLinkedList()

	list.Prepend(10)

	list.Prepend(20)

	list.Prepend(30)

	list.Append(50)

	list.Append(60)

	list.Remove(20)

	list.Remove(10)

	list.Remove(30)

	print(list)
}

func print(list *LinkedList) {
	current := list.Head

	for current != nil {
		fmt.Printf("%d\n", current.Value)

		current = current.Next
	}
}
