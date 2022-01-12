package main

import (
	"context"
	"testing"
	"time"
)

func TestThrottle(t *testing.T) {
	doubleEffector := func(ctx context.Context) (string, error) {
		return "OK", nil
	}

	throttle := Throttle(doubleEffector, 5, 1, 1*time.Second)

	results := make([]string, 10)

	for i := 0; i < 10; i++ {
		resp, _ := throttle(context.TODO())
		results[i] = resp
	}

	t.Log(results)
}
