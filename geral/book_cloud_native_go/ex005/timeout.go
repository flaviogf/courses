package main

import "context"

type SlowFunction func(string) (string, error)

type WithContext func(context.Context, string) (string, error)

func Timeout(f SlowFunction) WithContext {
	return func(ctx context.Context, arg string) (string, error) {
		chresp := make(chan string)
		cherr := make(chan error)

		go func() {
			resp, err := f(arg)
			chresp <- resp
			cherr <- err
		}()

		select {
		case <-ctx.Done():
			return "", ctx.Err()
		case resp := <-chresp:
			return resp, <-cherr
		}
	}
}
