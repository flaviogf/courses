package main

import (
	"context"
	"errors"
	"reflect"
	"testing"
	"time"
)

var ErrOps = errors.New("ops...")

type Result struct {
	resp string
	err  error
}

func TestBreaker(t *testing.T) {
	n := 0

	doubleCircuit := func(ctx context.Context) (string, error) {
		n++

		if n < 3 {
			return "", ErrOps
		}

		return "OK", nil
	}

	breaker := Breaker(doubleCircuit, 2)

	results := []Result{}

	for i := 0; i < 5; i++ {
		resp, err := breaker(context.Background())

		results = append(results, Result{resp, err})

		if err == ErrServiceUnreachable {
			time.Sleep(5 * time.Second)
		}
	}

	expectedResults := []Result{
		Result{"", ErrOps},
		Result{"", ErrOps},
		Result{"", ErrServiceUnreachable},
		Result{"OK", nil},
		Result{"OK", nil},
	}

	if !reflect.DeepEqual(results, expectedResults) {
		t.Errorf("got: %v, want: %v", results, expectedResults)
	}
}
