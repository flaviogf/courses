package main

import "context"

type Circuit func(ctx context.Context) (string, error)

func Breaker(circuit Circuit, failureThreshold int) Circuit {
	return func(ctx context.Context) (string, error) {
		return circuit(ctx)
	}
}
