package main

import "fmt"

func main() {
	slice := []int{1, 2, 3}

	fmt.Println(slice)

	slice = append(slice, 42, 27)

	fmt.Println(slice)

	s1 := slice[:]

	s2 := slice[1:]

	s3 := slice[:2]

	s4 := slice[1:2]

	fmt.Println(s1)

	fmt.Println(s2)

	fmt.Println(s3)

	fmt.Println(s4)
}
