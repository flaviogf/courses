package main

import "fmt"

type Node struct {
	Value interface{}
	Prev  *Node
	Next  *Node
}

func NewNode(value interface{}, prev *Node, next *Node) *Node {
	return &Node{value, prev, next}
}

type LinkedList struct {
	Head   *Node
	Tail   *Node
	length int
}

func NewLinkedList() *LinkedList {
	return &LinkedList{}
}

func (l *LinkedList) Append(value interface{}) {
	if l.IsEmpty() {
		l.Head = NewNode(value, nil, nil)
		l.Tail = l.Head
	} else {
		l.Tail.Next = NewNode(value, l.Tail, nil)
		l.Tail = l.Tail.Next
	}

	l.length++
}

func (l *LinkedList) Prepend(value interface{}) {
	if l.IsEmpty() {
		l.Head = NewNode(value, nil, nil)
		l.Tail = l.Head
	} else {
		l.Head = NewNode(value, nil, l.Head)
	}

	l.length++
}

func (l *LinkedList) PeekFirst() interface{} {
	return l.Head.Value
}

func (l *LinkedList) PeekLast() interface{} {
	return l.Tail.Value
}

func (l *LinkedList) RemoveFirst() interface{} {
	value := l.Head.Value

	l.Head = l.Head.Next

	l.length--

	if l.IsEmpty() {
		l.Tail = nil
	} else {
		l.Head.Prev = nil
	}

	return value
}

func (l *LinkedList) RemoveLast() interface{} {
	// TODO: not implemented

	return nil
}

func (l *LinkedList) Remove(node *Node) interface{} {
	// TODO: not implemented

	return nil
}

func (l *LinkedList) IndexOf(value interface{}) int {
	// TODO: not implemented

	return -1
}

func (l *LinkedList) Contains(value interface{}) bool {
	// TODO: not implemented

	return false
}

func (l *LinkedList) Clear() {
	// TODO: not implemented
}

func (l *LinkedList) Iterate() []interface{} {
	values := []interface{}{}

	current := l.Head

	for current != nil {
		values = append(values, current.Value)

		current = current.Next
	}

	return values
}

func (l *LinkedList) IsEmpty() bool {
	return l.Length() == 0
}

func (l *LinkedList) Length() int {
	return l.length
}

func (l *LinkedList) String() string {
	result := "["

	current := l.Head

	for current != nil {
		if current.Next != nil {
			result += fmt.Sprintf("%v,", current.Value)
		} else {
			result += fmt.Sprintf("%v", current.Value)
		}

		current = current.Next
	}

	result += "]"

	return result
}

func main() {
	list := NewLinkedList()

	list.Append(10)

	list.Append(20)

	list.Prepend(30)

	list.Prepend(40)

	fmt.Println(list.String())
}
