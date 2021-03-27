package main

import "testing"

func TestBinarySearch(t *testing.T) {
	numbers := []int{3, 5, 6, 7, 9, 10, 13, 14, 18, 20, 24, 32, 69}

	target := 20

	got := binarySearch(numbers, 0, len(numbers)-1, target)

	expected := 9

	if got != expected {
		t.Errorf("Did not get expected result. Got: %v, Want: %v", got, expected)
	}
}
