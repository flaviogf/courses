package main

import "fmt"

type User struct {
	ID        int
	FirstName string
	LastName  string
}

func main() {
	frank := User{1, "Frank", "Castle"}

	fmt.Println(frank)

	var peter User
	peter.ID = 2
	peter.FirstName = "Peter"
	peter.LastName = "Parker"

	fmt.Println(peter)
}
