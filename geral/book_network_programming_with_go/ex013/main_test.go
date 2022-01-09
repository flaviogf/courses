package main

import (
	"bytes"
	"fmt"
	"html/template"
	"io"
	"io/ioutil"
	"log"
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
		{http.MethodGet, nil, http.StatusOK, "Hello, friend!"},
		{http.MethodPost, bytes.NewBufferString("<world>"), http.StatusOK, "Hello, &lt;world&gt;!"},
		{http.MethodHead, nil, http.StatusMethodNotAllowed, ""},
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

		if resp.StatusCode != c.code {
			t.Errorf("#%d got: %d, want: %d", i+1, resp.StatusCode, c.code)
		}

		b, err := ioutil.ReadAll(resp.Body)

		if err != nil {
			t.Fatal(err)
		}

		_ = resp.Body.Close()

		if c.response != string(b) {
			t.Errorf("#%d got: %q, want: %q", i+1, b, c.response)
		}
	}

	if err := srv.Close(); err != nil {
		t.Fatal(err)
	}
}

func DefaultHandler() http.Handler {
	t := template.Must(template.New("hello").Parse("Hello, {{.}}!"))

	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		var b []byte

		switch r.Method {
		case http.MethodGet:
			b = []byte("friend")
		case http.MethodPost:
			var err error
			b, err = ioutil.ReadAll(r.Body)

			if err != nil {
				log.Fatal(err)
			}
		default:
			w.WriteHeader(http.StatusMethodNotAllowed)
			return
		}

		t.Execute(w, string(b))
	})
}
