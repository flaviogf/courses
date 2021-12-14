package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	counts := make(map[string]int)
	files := os.Args[1:]

	if len(files) == 0 {
		countLines(os.Stdin, counts)
		printCounts(counts)
		return
	}

	for _, arg := range files {
		f, err := os.Open(arg)

		if err != nil {
			fmt.Fprintf(os.Stderr, "dup: %v\n", err)
			continue
		}

		defer f.Close()

		countLines(f, counts)
	}

	printCounts(counts)
}

func countLines(f *os.File, counts map[string]int) {
	input := bufio.NewScanner(f)

	for input.Scan() {
		counts[input.Text()]++
	}
}

func printCounts(counts map[string]int) {
	for line, n := range counts {
		if n > 1 {
			fmt.Printf("%d\t%s\n", n, line)
		}
	}
}
