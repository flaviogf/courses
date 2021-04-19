package mylib

import "testing"

func TestAdd(t *testing.T) {
	if Add(10, 10) != 20 {
		t.Fail()
	}
}
