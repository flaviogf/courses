package main

import (
	"fmt"
	"io/ioutil"
	"os"
	"path/filepath"
	"testing"
)

func TestUnixDomainSocket(t *testing.T) {
	dir, err := ioutil.TempDir(os.TempDir(), "*_echo_unix")

	if err != nil {
		t.Fatal(err)
	}

	defer func() {
		if rErr := os.RemoveAll(dir); rErr != nil {
			t.Fatal(rErr)
		}
	}()

	socket := filepath.Join(dir, fmt.Sprintf("%d.sock", os.Getpid()))

	t.Log(socket)
}
