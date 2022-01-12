package main

import (
	"context"
	"reflect"
	"testing"
	"time"
)

type Result struct {
	resp string
	err  error
}

func TestThrottle(t *testing.T) {
	doubleEffector := func(ctx context.Context) (string, error) {
		return "OK", nil
	}

	throttle := Throttle(doubleEffector, 5, 1, 1*time.Second)

	results := []Result{}

	for i := 0; i < 10; i++ {
		resp, err := throttle(context.TODO())
		r := Result{resp, err}
		results = append(results, r)
	}

	time.Sleep(2 * time.Second)

	resp, err := throttle(context.TODO())
	r := Result{resp, err}
	results = append(results, r)

	expectedResults := []Result{
		Result{"OK", nil},
		Result{"OK", nil},
		Result{"OK", nil},
		Result{"OK", nil},
		Result{"OK", nil},
		Result{"", ErrTooManyCalls},
		Result{"", ErrTooManyCalls},
		Result{"", ErrTooManyCalls},
		Result{"", ErrTooManyCalls},
		Result{"", ErrTooManyCalls},
		Result{"OK", nil},
	}

	if !reflect.DeepEqual(results, expectedResults) {
		t.Errorf("want: %v, got: %v", expectedResults, results)
	}
}
