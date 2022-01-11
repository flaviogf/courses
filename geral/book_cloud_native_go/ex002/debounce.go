package main

import (
	"context"
	"time"
)

type Circuit func(ctx context.Context) (string, error)

func Debounce(circuit Circuit, d time.Duration) Circuit {
	return func(ctx context.Context) (string, error) {
		return circuit(ctx)
	}
}
