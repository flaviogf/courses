package main

import (
	"net/http"
	"net/http/httptest"
	"testing"
	"time"
)

func TestRacer(t *testing.T) {
	slowServer := makeDelayedServer(1 * time.Millisecond)
	fastServer := makeDelayedServer(0 * time.Millisecond)

	defer slowServer.Close()
	defer fastServer.Close()

	slowURL := slowServer.URL
	fastURL := fastServer.URL

	got, _ := Racer(slowURL, fastURL)

	if got != fastURL {
		t.Errorf("got: %s, want: %s", got, fastURL)
	}

	t.Run("when could not get a response before the specified delay", func(t *testing.T) {
		slowServer := makeDelayedServer(2 * time.Millisecond)
		fastServer := makeDelayedServer(3 * time.Millisecond)

		defer slowServer.Close()
		defer fastServer.Close()

		slowURL := slowServer.URL
		fastURL := fastServer.URL

		_, err := ConfigurableRacer(slowURL, fastURL, 1*time.Millisecond)

		if err == nil {
			t.Fatal("did not get an error but wanted one")
		}
	})
}

func makeDelayedServer(delay time.Duration) *httptest.Server {
	return httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		time.Sleep(delay)
		w.WriteHeader(204)
	}))
}
