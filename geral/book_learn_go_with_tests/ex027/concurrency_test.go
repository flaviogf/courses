package main

import (
	"reflect"
	"testing"
)

type DoubleChecker struct{}

func (dc *DoubleChecker) Check(url string) bool {
	if url == "https://fail.com" {
		return false
	}

	return true
}

func TestCheckWebsites(t *testing.T) {
	c := &DoubleChecker{}

	urls := []string{
		"https://google.com",
		"https://youtube.com",
		"https://fail.com",
	}

	got := CheckWebsites(c, urls)

	want := map[string]bool{
		"https://google.com":  true,
		"https://youtube.com": true,
		"https://fail.com":    false,
	}

	if !reflect.DeepEqual(got, want) {
		t.Errorf("got: %v, want: %v", got, want)
	}
}
