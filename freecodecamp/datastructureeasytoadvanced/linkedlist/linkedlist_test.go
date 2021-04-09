package main

import "testing"

func TestAppend(t *testing.T) {
	list := NewLinkedList()

	list.Append(10)

	list.Append(20)

	list.Append(30)

	if list.Length() != 3 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 3, list.Length())
	}

	if list.Head.Value != 10 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 10, list.Head.Value)
	}

	if list.Tail.Value != 30 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 30, list.Tail.Value)
	}
}

func TestPrepend(t *testing.T) {
	list := NewLinkedList()

	list.Prepend(10)

	list.Prepend(20)

	list.Prepend(30)

	if list.Length() != 3 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 3, list.Length())
	}

	if list.Head.Value != 30 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 30, list.Head.Value)
	}

	if list.Tail.Value != 10 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 10, list.Tail.Value)
	}
}

func TestRemoveFirst(t *testing.T) {
	list := NewLinkedList()

	list.Append(10)

	list.Append(20)

	list.RemoveFirst()

	if list.Length() != 1 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 1, list.Length())
	}

	if list.Head.Value != 20 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 20, list.Head)
	}

	if list.Head.Prev != nil {
		t.Errorf("it did not get the expected result. expected: nil, got: %v", list.Head)
	}

	list.RemoveFirst()

	if list.Head != nil {
		t.Errorf("it did not get the expected result. expected: nil, got: %v", list.Head)
	}

	if list.Tail != nil {
		t.Errorf("it did not get the expected result. expected: nil, got: %v", list.Tail)
	}
}

func TestIterate(t *testing.T) {
	list := NewLinkedList()

	list.Append(10)

	list.Append(20)

	list.Prepend(30)

	list.Prepend(40)

	values := list.Iterate()

	if values[0] != 40 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 40, values[0])
	}

	if values[1] != 30 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 30, values[1])
	}

	if values[2] != 10 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 30, values[2])
	}

	if values[3] != 20 {
		t.Errorf("it did not get the expected result. expected: %v got: %v", 30, values[3])
	}
}

func TestIsEmpty(t *testing.T) {
	list := NewLinkedList()

	if list.IsEmpty() != true {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", true, list.IsEmpty())
	}
}

func TestLength(t *testing.T) {
	list := NewLinkedList()

	if list.Length() != 0 {
		t.Errorf("it did not get the expected result. expected: %v, got: %v", 0, list.Length())
	}
}
