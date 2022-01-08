package main

import (
	"net/http"
	"testing"
	"time"
)

func TestHeadTime(t *testing.T) {
	resp, err := http.Head("https://time.gov")

	if err != nil {
		t.Fatal(err)
	}

	_ = resp.Body.Close()

	dateStr := resp.Header.Get("Date")

	if dateStr == "" {
		t.Fatal("did not get a date from time.gov")
	}

	now := time.Now().Round(time.Second)

	date, err := time.Parse(time.RFC1123, dateStr)

	if err != nil {
		t.Fatal(err)
	}

	t.Logf("time.gov: %s (skew: %s)", date, now.Sub(date))
}
