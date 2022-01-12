package main

import (
	"context"
	"errors"
	"testing"
	"time"
)

var ErrOops = errors.New("oops...")

func TestRetry(t *testing.T) {
	n := 0

	doubleEffector := func(ctx context.Context) (string, error) {
		n++

		if n < 3 {
			return "", ErrOops
		}

		return "OK", nil
	}

	retry := Retry(doubleEffector, 5, 5*time.Millisecond)
	resp, err := retry(context.TODO())

	if err != nil {
		t.Errorf("did not want an error, but got one err: %v", err)
	}

	if resp != "OK" {
		t.Errorf("want: %s, got: %s", "OK", resp)
	}
}
