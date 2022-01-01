package main

import (
	"bytes"
	"errors"
	"net"
	"testing"
	"time"
)

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
	buf := &bytes.Buffer{}
	url := "scanme.nmap.org"
	port := 80
	c := &DoubleConn{}

	_ = Scan(buf, url, port, func(_, _ string) (net.Conn, error) {
		return c, nil
	})

	got := buf.String()
	want := "80 open\n"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}

	t.Run("when something goes wrong", func(t *testing.T) {
		buf := &bytes.Buffer{}
		url := "scanme.nmap.org"
		port := 80

		err := Scan(buf, url, port, func(_, _ string) (net.Conn, error) {
			return nil, errors.New("ops")
		})

		if err == nil {
			t.Error("did not get an error but wanted one")
		}
	})
}
