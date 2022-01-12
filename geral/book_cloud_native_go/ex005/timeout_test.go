package main

import (
	"context"
	"testing"
	"time"
)

func TestTimeout(t *testing.T) {
	slow := func(arg string) (string, error) {
		time.Sleep(1 * time.Second)
		return "OK", nil
	}

	timeout := Timeout(slow)
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Millisecond)
	defer cancel()

	_, err := timeout(ctx, "something")

	if err != context.DeadlineExceeded {
		t.Error("did not get an error, but would want one")
	}
}
