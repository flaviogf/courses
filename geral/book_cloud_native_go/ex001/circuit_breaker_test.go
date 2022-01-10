package main

import (
	"context"
	"testing"
)

func TestBreaker(t *testing.T) {
	doubleCircuit := func(ctx context.Context) (string, error) {
		return "", nil
	}

	breaker := Breaker(doubleCircuit, 5)

	_, err := breaker(context.Background())

	if err != nil {
		t.Error("did not want an error, but got one")
	}
}
