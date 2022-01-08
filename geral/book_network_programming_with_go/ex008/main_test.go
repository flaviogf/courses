package main

import (
	"io/ioutil"
	"os"
	"testing"
)

func TestUnixDomainSocket(t *testing.T) {
	dir, err := ioutil.TempDir(os.TempDir(), "*_echo_unix")

	if err != nil {
		t.Fatal(err)
	}

	t.Log(dir)

	defer func() {
		if rErr := os.RemoveAll(dir); rErr != nil {
			t.Fatal(rErr)
		}
	}()
}
