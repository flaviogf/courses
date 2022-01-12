package main

import (
	"context"
	"errors"
	"sync"
	"time"
)

var ErrTooManyCalls = errors.New("too many calls")

type Effector func(ctx context.Context) (string, error)

func Throttle(effector Effector, max, refil int, delay time.Duration) Effector {
	tokens := max
	once := sync.Once{}

	return func(ctx context.Context) (string, error) {
		once.Do(func() {
			ticker := time.NewTicker(delay)

			go func(ctx context.Context) {
				defer ticker.Stop()

				for {
					select {
					case <-ctx.Done():
						return
					case <-ticker.C:

						t := tokens + refil

						if t > max {
							t = max
						}

						tokens = t
					}
				}
			}(ctx)
		})

		if tokens <= 0 {
			return "", ErrTooManyCalls
		}

		tokens--

		return effector(ctx)
	}
}
