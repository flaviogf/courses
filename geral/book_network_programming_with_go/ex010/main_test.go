package main

import (
	"context"
	"errors"
	"net/http"
	"net/http/httptest"
	"testing"
	"time"
)

func TestTimeout(t *testing.T) {
	s := httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		select {}
	}))

	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Millisecond)

	defer cancel()

	req, err := http.NewRequestWithContext(ctx, http.MethodGet, s.URL, nil)

	if err != nil {
		t.Fatal(err)
	}

	_, err = http.DefaultClient.Do(req)

	if err == nil || !errors.Is(err, context.DeadlineExceeded) {
		t.Fatal(err)
	}
}
