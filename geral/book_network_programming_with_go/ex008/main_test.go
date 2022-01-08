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

	defer func() {
		if rErr := os.RemoveAll(dir); rErr != nil {
			t.Fatal(rErr)
		}
	}()

	t.Log(dir)
}
