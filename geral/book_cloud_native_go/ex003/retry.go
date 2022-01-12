package main

import (
	"context"
	"time"
)

type Effector func(ctx context.Context) (string, error)

func Retry(effector Effector, retries int, delay time.Duration) Effector {
	return func(ctx context.Context) (string, error) {
		for r := 0; ; r++ {
			resp, err := effector(ctx)

			if err == nil || r >= retries {
				return resp, err
			}

			select {
			case <-time.After(delay):
			case <-ctx.Done():
				return "", ctx.Err()
			}
		}
	}
}
