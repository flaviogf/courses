package main

import (
	"context"
	"testing"
	"time"
)

func TestDebounce(t *testing.T) {
	doubleCircuit := func(ctx context.Context) (string, error) {
		return "OK", nil
	}

	debounce := Debounce(doubleCircuit, 5*time.Second)

	_, err := debounce(context.Background())

	if err != nil {
		t.Error("did not want an error, but got one")
	}
}
