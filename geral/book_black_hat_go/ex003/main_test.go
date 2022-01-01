package main

import (
	"bytes"
	"testing"
)

type DoubleConn struct {
	Calls int
}

func (dc *DoubleConn) Close() error {
	dc.Calls += 1
	return nil
}

func TestScan(t *testing.T) {
	buf := &bytes.Buffer{}
	url := "scanme.nmap.org"
	port := 80
	conn := &DoubleConn{}

	_ = Scan(buf, url, port, func(_, _ string) (Conn, error) {
		return conn, nil
	})

	got := buf.String()
	want := "80 open\n"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}
