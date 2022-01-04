package main

import (
	"log"
	"os"
	"os/exec"
)

func main() {
	cmd := exec.Command("/bin/sh", "-i")
	cmd.Stdin = os.Stdin
	cmd.Stdout = os.Stdout
	if err := cmd.Run(); err != nil {
		log.Fatal(err)
	}
}
