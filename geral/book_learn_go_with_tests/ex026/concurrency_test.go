package main

import (
	"reflect"
	"testing"
)

type DoubleChecker struct{}

func (dc *DoubleChecker) Check(url string) bool {
	if url == "https://www.wrong.com" {
		return false
	}

	return true
}

func TestCheckWebsites(t *testing.T) {
	urls := []string{
		"https://www.google.com",
		"https://www.youtube.com",
		"https://www.wrong.com",
	}

	c := &DoubleChecker{}

	got := CheckWebsites(c, urls)

	want := map[string]bool{
		"https://www.google.com":  true,
		"https://www.youtube.com": true,
		"https://www.wrong.com":   false,
	}

	if !reflect.DeepEqual(got, want) {
		t.Errorf("got: %v, want: %v", got, want)
	}
}
