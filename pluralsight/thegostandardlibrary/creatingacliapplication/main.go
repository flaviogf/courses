package main

import (
	"bufio"
	"fmt"
	"os"
	"runtime"
)

func main() {
	fmt.Println("What is your name?")

	reader := bufio.NewReader(os.Stdin)

	name, _ := reader.ReadString('\n')

	fmt.Printf("Hello %v", name)

	fmt.Printf("We are running go version %v in %v\n", runtime.Version(), runtime.GOOS)
}
