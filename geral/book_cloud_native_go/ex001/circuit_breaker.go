package main

import (
	"context"
	"errors"
	"sync"
	"time"
)

var ErrServiceUnreachable = errors.New("service unreachable")

type Circuit func(ctx context.Context) (string, error)

func Breaker(circuit Circuit, failureThreshold int) Circuit {
	consecutiveFailures := 0
	lastAttempt := time.Now()
	m := &sync.RWMutex{}

	return func(ctx context.Context) (string, error) {
		m.RLock()

		diff := consecutiveFailures - failureThreshold

		if diff >= 0 {
			shouldRetryAt := lastAttempt.Add(5 * time.Second)

			if time.Now().Before(shouldRetryAt) {
				m.RUnlock()
				return "", ErrServiceUnreachable
			}
		}

		m.RUnlock()

		resp, err := circuit(ctx)

		m.Lock()
		defer m.Unlock()

		lastAttempt = time.Now()

		if err != nil {
			consecutiveFailures++
			return resp, err
		}

		consecutiveFailures = 0

		return resp, err
	}
}
