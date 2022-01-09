package main

import (
	"fmt"
	"io"
	"net"
	"net/http"
	"testing"
	"time"
)

func TestSimpleHTTPServer(t *testing.T) {
	srv := &http.Server{
		Addr:              "127.0.0.1:8081",
		Handler:           http.TimeoutHandler(DefaultHandler(), 2*time.Minute, ""),
		IdleTimeout:       5 * time.Minute,
		ReadHeaderTimeout: time.Minute,
	}

	l, err := net.Listen("tcp", srv.Addr)

	if err != nil {
		t.Fatal(err)
	}

	go func() {
		err := srv.Serve(l)

		if err != http.ErrServerClosed {
			t.Fatal(err)
		}
	}()

	testCases := []struct {
		method   string
		body     io.Reader
		code     int
		response string
	}{
		{http.MethodGet, nil, http.StatusOK, "Hello, friend"},
	}

	client := &http.Client{}
	path := fmt.Sprintf("http://%s/", srv.Addr)

	for i, c := range testCases {
		req, err := http.NewRequest(c.method, path, c.body)

		if err != nil {
			t.Fatal(err)
		}

		resp, err := client.Do(req)

		if err != nil {
			t.Fatal(err)
		}

		if resp.StatusCode != http.StatusOK {
			t.Errorf("#%d got: %d, want: %d", i, resp.StatusCode, http.StatusOK)
		}
	}
}

func DefaultHandler() http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		w.WriteHeader(200)
	})
}
