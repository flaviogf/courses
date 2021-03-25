package main

import "testing"

func TestCreateLinkedListReturnsFiveChildren(t *testing.T) {
	child := createLinkedList(5, nil)

	got := 0

	for ; child != nil; child = child.Pointer {
		got++
	}

	expected := 5

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}

func BenchmarkCreateLinkedList(b *testing.B) {
	for i := 0; i < b.N; i++ {
		createLinkedList(5, nil)
	}
}
