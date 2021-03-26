package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	s := make(chan string)

	t1 := make(chan string)

	t2 := make(chan string)

	var offset int32 = 3

	go tower1(s, t1, offset)

	go tower2(s, t2, offset)

	for i := 0; i < 2; i++ {
		select {
		case msg := <-t1:
			fmt.Printf("Message sent by t1 : %s\n", msg)
		case msg := <-t2:
			fmt.Printf("Message received by t2: %s\n", msg)
		}
	}

}

func tower1(s chan string, t1 chan string, offset int32) {
	reader := bufio.NewReader(os.Stdin)

	input, _ := reader.ReadString('\n')

	var output string

	for _, c := range input {
		output += string(c + offset)
	}

	t1 <- output

	s <- output
}

func tower2(s chan string, t2 chan string, offset int32) {
	input := <-s

	var output string

	for _, c := range input {
		output += string(c - offset)
	}

	t2 <- output
}
