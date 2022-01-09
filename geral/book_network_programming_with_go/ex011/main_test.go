package main

import (
	"bytes"
	"encoding/json"
	"io"
	"net/http"
	"net/http/httptest"
	"testing"
)

type User struct {
	FirstName string
	LastName  string
}

func TestPostUser(t *testing.T) {
	s := httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		defer func(r *http.Request) {
			_, _ = io.Copy(io.Discard, r.Body)
			_ = r.Body.Close()
		}(r)

		var user User
		err := json.NewDecoder(r.Body).Decode(&user)

		if err != nil {
			t.Fatal(err)
		}

		t.Log(user)

		w.WriteHeader(http.StatusAccepted)
	}))

	defer s.Close()

	buf := &bytes.Buffer{}
	user := &User{"Frank", "Castle"}
	err := json.NewEncoder(buf).Encode(user)

	if err != nil {
		t.Fatal(err)
	}

	resp, err := http.Post(s.URL, "application/json", buf)

	if err != nil {
		t.Fatal(err)
	}

	if resp.StatusCode != http.StatusAccepted {
		t.Errorf("got: %d, want: %d", resp.StatusCode, http.StatusAccepted)
	}
}
