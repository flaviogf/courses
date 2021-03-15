package main

import (
	"fmt"
	"flag"
)

func main() {
	arch := flag.String("arch", "x86", "CPU type")

	flag.Parse()

	switch *arch {
	case "x86":
		fmt.Println("Running in 32 bit mode")
	case "AMD64":
		fmt.Println("Running in 64 bit mode")
	}

	fmt.Println("Process completed!")
}
