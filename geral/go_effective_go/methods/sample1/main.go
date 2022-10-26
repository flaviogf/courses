package main

import "fmt"

type ByteSlice []byte

func (p *ByteSlice) Write(data []byte) (int, error) {
	slice := *p

	l := len(slice)

	if l+len(data) > cap(slice) {
		newSlice := make([]byte, (l+len(data))*2)
		copy(newSlice, slice)
		slice = newSlice
	}

	slice = slice[0 : l+len(data)]
	copy(slice[l:], data)

	*p = slice

	return len(data), nil
}

func main() {
	var b ByteSlice
	fmt.Fprintf(&b, "this hour has %d days\n", 7)
	fmt.Printf("%s", b)
	fmt.Println("finished")
}
