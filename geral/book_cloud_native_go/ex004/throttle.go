package main

import (
	"context"
	"time"
)

type Effector func(ctx context.Context) (string, error)

func Throttle(effector Effector, max, refil int, d time.Duration) Effector {
	return func(ctx context.Context) (string, error) {
		return effector(ctx)
	}
}
