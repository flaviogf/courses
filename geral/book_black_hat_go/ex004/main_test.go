package main

import (
	"bytes"
	"net"
	"testing"
	"time"
)

type DoubleFinisher struct {
	DoneCalls int
}

func (d *DoubleFinisher) Done() {
	d.DoneCalls += 1
}

type DoubleConn struct {
	CloseCalls int
}

func (d *DoubleConn) Read(b []byte) (n int, err error) {
	panic("not implemented")
}

func (d *DoubleConn) Write(b []byte) (n int, err error) {
	panic("not implemented")
}

func (d *DoubleConn) Close() error {
	d.CloseCalls += 1
	return nil
}

func (d *DoubleConn) LocalAddr() net.Addr {
	panic("not implemented")
}

func (d *DoubleConn) RemoteAddr() net.Addr {
	panic("not implemented")
}

func (d *DoubleConn) SetDeadline(t time.Time) error {
	panic("not implemented")
}

func (d *DoubleConn) SetReadDeadline(t time.Time) error {
	panic("not implemented")
}

func (d *DoubleConn) SetWriteDeadline(t time.Time) error {
	panic("not implemented")
}

func TestScan(t *testing.T) {
	b := &bytes.Buffer{}
	url := "scanme.nmap.org"
	port := 80
	f := &DoubleFinisher{}
	conn := &DoubleConn{}

	_ = Scan(b, url, port, f, func(_, _ string) (net.Conn, error) {
		return conn, nil
	})

	got := b.String()
	want := "80 open\n"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}

	if f.DoneCalls != 1 {
		t.Errorf("%s got %d calls, but want %d", "Done", f.DoneCalls, 1)
	}

	if conn.CloseCalls != 1 {
		t.Errorf("%s got %d calls, but want %d", "Close", conn.CloseCalls, 1)
	}
}
